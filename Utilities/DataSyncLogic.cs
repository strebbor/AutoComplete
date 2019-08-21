using IDComplete.Entities;
using IDComplete.Interfaces;
using System;
using IDComplete;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IDComplete.Utilities
{
    public class DataSyncLogic
    {
        private readonly List<ColumnSetup> AllColumnSetups;
        private readonly IDataSource DataStore;
        public DataSyncLogic(IDataSource columnSetup, IDataSource database)
        {
            AllColumnSetups = columnSetup.GetAllData<List<ColumnSetup>>();
            DataStore = database;
        }
        public DataSyncLogic(bool supressPreloading)
        {
        }
        public DataTable ClassifyData(DataTable workingDataSet)
        {
            workingDataSet.Columns.Add("New");
            workingDataSet.Columns.Add("Changed");
            workingDataSet.Columns.Add("Excluded");
            var isNewColumnIndex = workingDataSet.Columns.IndexOf("New");
            var isChangedColumnIndex = workingDataSet.Columns.IndexOf("Changed");
            var isExludedColumnIndex = workingDataSet.Columns.IndexOf("Excluded");

            for (int rowCounter = 0; rowCounter < workingDataSet.Rows.Count; rowCounter++)
            {
                DataRow currentRow = workingDataSet.Rows[rowCounter];
                DataTable results;

                //do row calculations and override current row
                currentRow = DoRowCalculations(currentRow);

                if (IsRowExcluded(currentRow))
                {
                    currentRow[isExludedColumnIndex] = true;
                }
                else
                {
                    if (IsRowNew(currentRow, out results))
                    {
                        currentRow[isNewColumnIndex] = true; //this is a new entry
                    }
                    else
                    {
                        currentRow[isChangedColumnIndex] = AreRowsDifferent(currentRow, results.Rows[0]); //this value was found, now we need to see if it is changed
                    }
                }
            }

            return workingDataSet;
        }
        private DataRow DoRowCalculations(DataRow rowToCalculate)
        {
            foreach (ColumnSetup column in AllColumnSetups)
            {
                var valueToUse = rowToCalculate[column.Key];

                if (column.CalculationSetup != null && string.IsNullOrWhiteSpace(valueToUse.ToString()))
                {
                    string valueToUseInCalculation = rowToCalculate[column.CalculationSetup.FieldToUse].ToString();
                    rowToCalculate[column.Key] = DataHelpers.DoCalculation(column.CalculationSetup.Type, valueToUseInCalculation);
                }
            }

            return rowToCalculate;
        }
        private DataTable EncryptColumns(DataTable tableToEncrypt)
        {
            var encryptedColumns = AllColumnSetups.FindAll(x => x.Encrypted);
            for (int i = 0; i < tableToEncrypt.Rows.Count; i++)
            {
                DataRow workingRow = tableToEncrypt.Rows[i];
                foreach (ColumnSetup encryptedColumn in encryptedColumns)
                {
                    workingRow[encryptedColumn.Key] = Security.Encrypt(workingRow[encryptedColumn.Key].ToString());
                }
            }
            return tableToEncrypt;
        }
        public int UpdateDatasource(DataTable updatedData)
        {
            int rowsUpdated = 0;
            updatedData.Columns.Add("Saved");

            updatedData = EncryptColumns(updatedData);

            for (int i = 0; i < updatedData.Rows.Count; i++)
            {
                DataRow row = updatedData.Rows[i];
                IQuery queryToRun = GetQueryToRun(row);

                if (queryToRun != null)
                {
                    string saveStatus = ExecuteQuery(queryToRun, row);
                    row["Saved"] = saveStatus;
                    if (saveStatus == "Successful")
                    {
                        rowsUpdated++;
                    }
                }
            }

            return rowsUpdated;
        }
        private IQuery GetQueryToRun(DataRow row)
        {
            bool isRowNew;
            bool.TryParse(row["New"].ToString(), out isRowNew);
            bool isRowUpdated;
            bool.TryParse(row["Changed"].ToString(), out isRowUpdated);           

            if (isRowNew)
            {
                return new InsertQuery();
            }
            if (isRowUpdated)
            {
                return new UpdateQuery();
            }          

            return null;
        }
        private string ExecuteQuery(IQuery queryToRun, DataRow row)
        {
            var query = DataHelpers.BuildQuery(queryToRun, AllColumnSetups, row);
            var results = DataStore.Execute(query);

            //set the saved status on the row
            var saveStatus = "Failed";
            if (results != null)
            {
                DataTable dtResults = (DataTable)results;
                if (dtResults.Rows.Count > 0)
                {
                    saveStatus = "Successful";
                }
            }

            return saveStatus;
        }
        private bool IsRowNew(DataRow rowToCheck, out DataTable results)
        {
            string query = DataHelpers.BuildQuery(new SelectQuery(), AllColumnSetups, rowToCheck);
            results = DataStore.Read<DataTable>(query);
            return (results.Rows.Count < 1);
        }
        public bool AreRowsDifferent(DataRow firstRow, DataRow secondRow)
        {
            foreach (ColumnSetup column in AllColumnSetups)
            {
                var rowValue = firstRow[column.Key].ToString();
                var dbValue = secondRow[column.Key].ToString();

                if (column.IsPrimaryKey)
                {
                    rowValue = Security.Encrypt(rowValue);
                }

                if (rowValue.ToUpper() != dbValue.ToUpper())
                {
                    return true;
                }
            }

            return false;
        }
        public bool IsRowExcluded(DataRow rowToCheck)
        {
            foreach (ColumnSetup column in AllColumnSetups)
            {
                if (column.ValuesToExclude != null)
                {
                    var matches = column.ValuesToExclude.Find(x => x.Value.ToUpper() == rowToCheck[column.Key].ToString().ToUpper());
                    if (matches != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
