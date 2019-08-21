using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using IDComplete.CustomControls;
using IDComplete.Interfaces;
using IDComplete.DataSources;
using IDComplete.Entities;
using System.Data;
using IDComplete.Utilities;
using System.IO;
using Newtonsoft.Json;

namespace IDComplete
{
    public partial class Ribbon
    {
        private LookupScreen _lookupScreen;
        private SetupScreen _setupScreen;
        private DataSynchronizerScreen _syncScreen;

        private Excel.Worksheet activeWorksheet;

        private int _workingRowNumber;
        private string _triggerChar;
        private List<ColumnSetup> allColumnsSetup;
        private bool rowUpdateInProgress = false;
        private bool _monitorRunning = false;

        private IDataSource database;
        private IDataSource columnSetupSource;
        private IDataSource sheetSetupSource;

        private SheetSetup sheetSetup;
        private DataSyncLogic datasyncLogic;        

        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {            
            Setup();
            Globals.ThisAddIn.Application.WorkbookActivate += Application_WorkbookActivate;
        }

        private void StrapUpDatabase()
        {
            ApplicationSetup setup = new ApplicationSetup();

            setup.Initialise(new Uri(DataHelpers.ApplicationBaseDirectory + "Configs\\applicationSetup.json"));
            database = new SqlDataSource();
            database.Username = setup.DatabaseUsername;
            database.Password = setup.DatabasePassword;
            database.Name = setup.DatabaseName;
            database.Location = setup.DatabaseLocation;
        }

        private void StrapUpColumnSource()
        {
            columnSetupSource = new ColumnSetupDataSource();
            columnSetupSource.Path = new Uri(DataHelpers.ApplicationBaseDirectory + "Configs\\cellSetup.json");
            columnSetupSource.Initialise();
            allColumnsSetup = columnSetupSource.GetAllData<List<ColumnSetup>>();
        }
        private void StrapUpSheetSetupSource()
        {
            sheetSetupSource = new SheetSetupDataSource();
            sheetSetupSource.Path = new Uri(DataHelpers.ApplicationBaseDirectory + "Configs\\sheetSetup.json");
            sheetSetupSource.Initialise();
            sheetSetup = sheetSetupSource.GetAllData<SheetSetup>();
            _triggerChar = sheetSetup.TriggerChar;
        }
        private void Setup()
        {
            //initialise and setup application
            StrapUpDatabase();
            StrapUpColumnSource();
            StrapUpSheetSetupSource();
            datasyncLogic = new DataSyncLogic(columnSetupSource, database);
        }

        private void Application_WorkbookActivate(Excel.Workbook Wb)
        {
            UpdateMonitoringStatus(false);
        }

        private void ValueMatcher_RowSelected(List<KeyValuePair<string, string>> selectedRow)
        {
            rowUpdateInProgress = true;

            foreach (KeyValuePair<string, string> selectedColumn in selectedRow)
            {
                foreach (ColumnSetup columnSetup in allColumnsSetup)
                {
                    var workingColumn = activeWorksheet.Range[columnSetup.ColumnLetter + _workingRowNumber];
                    if (columnSetup.Key == selectedColumn.Key)
                    {
                        workingColumn.Value2 = selectedColumn.Value;
                        break;
                    }
                }
            }

            rowUpdateInProgress = false;
        }

        private void UpdateMonitoringStatus(bool status)
        {
            if (status)
            {
                btnStatus.Image = Properties.Resources.on;
                btnStatus.Label = "Status: On";
            }
            else
            {
                //change the status button           
                btnStatus.Image = Properties.Resources.off;
                btnStatus.Label = "Status: Off";
            }

            _monitorRunning = status;
        }

        private string GetCellValue(Excel.Range Target)
        {
            string cellValue = "";
            if (Target.Value2 != null)
            {
                cellValue = Target.Value2.ToString();
            }
            return cellValue;
        }

        private void ActiveWorksheet_Change(Excel.Range Target)
        {
            if (rowUpdateInProgress) { return; } //we do not care about checking values if we are busy updating the row

            if (Target.Column == columnSetupSource.GetIdentifier<ColumnSetup>().ColumnNumber)
            {
                _workingRowNumber = Target.Row;

                string cellValue = GetCellValue(Target);
                if (cellValue.ToUpper().Contains(_triggerChar))
                {
                    //get the string part to match (remove the trigger char instances)
                    var searchText = cellValue.Replace(_triggerChar, "");

                    //open the ID number auto complete box 
                    if (_lookupScreen == null || _lookupScreen.IsDisposed)
                    {
                        var data = DecryptColumns(database.GetAllData<DataTable>());
                        _lookupScreen = new LookupScreen(columnSetupSource, data);
                        _lookupScreen.RowSelected += ValueMatcher_RowSelected;
                    }

                    _lookupScreen.SearchText = searchText;
                    _lookupScreen.Show();
                }
            }
        }
        private DataTable DecryptColumns(DataTable tableToDecrypt)
        {
            List<ColumnSetup> allColumnSetups = columnSetupSource.GetAllData<List<ColumnSetup>>();
            var encryptedColumns = allColumnSetups.FindAll(x => x.Encrypted);
            for (int i = 0; i < tableToDecrypt.Rows.Count; i++)
            {
                DataRow workingRow = tableToDecrypt.Rows[i];
                foreach (ColumnSetup encryptedColumn in encryptedColumns)
                {
                    var rowValue = workingRow[encryptedColumn.Key].ToString();
                    if (rowValue.Length > 10)
                    {
                        workingRow[encryptedColumn.Key] = Security.Decrypt(rowValue);
                    }
                }
            }
            return tableToDecrypt;
        }
        private void BtnSetup_Click(object sender, RibbonControlEventArgs e)
        {
            if (_setupScreen == null || _setupScreen.IsDisposed)
            {
                _setupScreen = new SetupScreen(columnSetupSource, sheetSetupSource);
            }
            _setupScreen.Show();
        }

        private void BtnStatus_Click(object sender, RibbonControlEventArgs e)
        {
            activeWorksheet = Globals.ThisAddIn.Application.ActiveSheet;

            if (_monitorRunning)
            {
                //stops the application from monitoring
                activeWorksheet.Change -= ActiveWorksheet_Change;
            }
            else
            {
                //starts the application monitoring
                activeWorksheet.Change += ActiveWorksheet_Change;
            }

            UpdateMonitoringStatus(!_monitorRunning);
        }

        private void BtnSynchronize_Click(object sender, RibbonControlEventArgs e)
        {
            activeWorksheet = Globals.ThisAddIn.Application.ActiveSheet;

            UpdateMonitoringStatus(false);

            ShowDataSyncronizerScreen();
        }

        private void ShowDataSyncronizerScreen()
        {
            DataTable excelData = CreateDataTableFromExcel();

            if (excelData.Rows.Count < 1)
            {
                MessageBox.Show("No data found to synchronize");
                return;
            }

            if (_syncScreen == null || _syncScreen.IsDisposed)
            {
                _syncScreen = new DataSynchronizerScreen(datasyncLogic.ClassifyData(excelData), database, columnSetupSource);
                _syncScreen.ReloadScreen += _syncScreen_ReloadScreen;
            }
            _syncScreen.Show();
        }

        private void _syncScreen_ReloadScreen()
        {
            Setup();
            ShowDataSyncronizerScreen();
        }

        private object[,] GetValuesOfRange(int firstRow, int columnNumber, int rowNumber)
        {
            var usedRange = activeWorksheet.Range["A" + firstRow, DataHelpers.ExcelColumnFromNumber(columnNumber) + rowNumber];

            object valuesInSheet = usedRange.Value2;
            if (valuesInSheet == null)
            {
                return null;
            }

            if (valuesInSheet.GetType() != typeof(System.Object[,]))
            {
                //we do not want to do anything when there is only a single cell of data
                return null;
            }

            object[,] sheetValues = usedRange.Value2;

            return sheetValues;
        }

        private DataTable CreateDataTableFromExcel()
        {
            var firstRow = int.Parse(sheetSetup.FirstRow);

            Excel.Range lastUsedCell = activeWorksheet.Cells.Find("*", Type.Missing, Type.Missing, Type.Missing, Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlPrevious, false, Type.Missing, Type.Missing);

            if (lastUsedCell == null)
            {
                return new DataTable();
            }

            object[,] valuesOfUsedRange = GetValuesOfRange(firstRow, lastUsedCell.Column, lastUsedCell.Row);

            var totalRowsInRange = valuesOfUsedRange.GetLength(0);
            var totalColumnsInRange = valuesOfUsedRange.Length / totalRowsInRange;

            //setup a datatable to hold the data
            DataTable dtExcelData = new DataTable();
            foreach (var cellSetup in allColumnsSetup)
            {
                dtExcelData.Columns.Add(cellSetup.Key);
            }

            //fill the datatable with the two dimensional array according to the column numbers
            for (int i = 1; i <= totalRowsInRange; i++)
            {
                DataRow dr = dtExcelData.NewRow();
                foreach (var cellSetup in allColumnsSetup)
                {
                    if (cellSetup.ColumnNumber <= totalColumnsInRange)
                    {
                        dr[cellSetup.Key] = valuesOfUsedRange[i, cellSetup.ColumnNumber];
                    }
                }
                dtExcelData.Rows.Add(dr);
            }

            return dtExcelData;
        }
    }
}
