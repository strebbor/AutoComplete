using IDComplete.Interfaces;
using IDComplete.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDComplete.CustomControls
{
    public partial class DataSynchronizerScreen : Form
    {
        private DataTable dtMaster;
        private DataTable dtExcludedRows;
        private DataTable dtNewRows;
        private DataTable dtUpdatedRows;
        private DataTable dtUnchangedRows;

        public delegate void delReloadScreen();
        public event delReloadScreen ReloadScreen;

        private IDataSource Database;
        private IDataSource ColumnSetupSource;
        public DataSynchronizerScreen(DataTable dataSource, IDataSource database, IDataSource columnSetupSource)
        {
            InitializeComponent();

            Database = database;
            ColumnSetupSource = columnSetupSource;

            dtMaster = dataSource;

            dtExcludedRows = FilterDataTable("Excluded = true");
            dtNewRows = FilterDataTable("New = true");
            dtUpdatedRows = FilterDataTable("Changed = true");
            dtUnchangedRows = FilterDataTable("Changed = false And (New IS NULL OR New = False)");
            SetRowCounters();

            cbFilterOption.SelectedItem = "NEW";
        }

        private void SetRowCounters()
        {
            lblTotalRows.Text = dtMaster.Rows.Count.ToString();
            lblNewRows.Text = dtNewRows.Rows.Count.ToString();
            lblUpdatedRows.Text = dtUpdatedRows.Rows.Count.ToString();
            lblExcludedRows.Text = dtExcludedRows.Rows.Count.ToString();
        }
        private DataTable FilterDataTable(string query)
        {
            DataRow[] selection = dtMaster.Select(query);
            DataTable filteredTable = dtMaster.Clone();
            if (selection.Length > 0)
            {
                filteredTable = selection.CopyToDataTable<DataRow>();
            }

            return filteredTable;
        }
        private void FilterData(string filterOption)
        {
            switch (filterOption.ToUpper())
            {
                case "NEW":
                    {
                        gridData.DataSource = dtNewRows;
                    }
                    break;
                case "UPDATED":
                    {
                        gridData.DataSource = dtUpdatedRows;
                    }
                    break;
                case "UNCHANGED":
                    {
                        gridData.DataSource = dtUnchangedRows;
                    }
                    break;
                case "EXCLUDED":
                    {
                        gridData.DataSource = dtExcludedRows;
                    }
                    break;
            }

            gridData.Columns["New"].Visible = false;
            gridData.Columns["Changed"].Visible = false;
            gridData.Columns["Excluded"].Visible = false;
        }

        private void CbFilterOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData(cbFilterOption.SelectedItem.ToString());
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to save changes to the database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //combine the data tables and send to the database
                DataTable combinedTable = dtMaster.Clone();

                combinedTable.Merge(dtNewRows);
                combinedTable.Merge(dtUpdatedRows);
                combinedTable.Merge(dtUnchangedRows);
                var totalRowsToBeUpdated = dtNewRows.Rows.Count + dtUpdatedRows.Rows.Count;

                if (totalRowsToBeUpdated < 1)
                {
                    MessageBox.Show("No data available to be updated.  This screen will now close");
                    return;
                }

                DataSyncLogic syncer = new DataSyncLogic(ColumnSetupSource, Database);
                int rowsUpdated = 0;

                try
                {
                    rowsUpdated = syncer.UpdateDatasource(combinedTable);
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    throw;
                }

                if (rowsUpdated != totalRowsToBeUpdated)
                {
                    MessageBox.Show(rowsUpdated + " of " + totalRowsToBeUpdated + " has been updated. " + dtExcludedRows.Rows.Count + " rows has been excluded.  Failures are available in the logs");
                }
                else
                {
                    MessageBox.Show(rowsUpdated + " of " + totalRowsToBeUpdated + " has been updated. " + dtExcludedRows.Rows.Count + " rows has been excluded.");
                }

                ReloadScreen();
                Close();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            ReloadScreen();
            Close();
        }
    }
}
