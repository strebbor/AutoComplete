using IDComplete.DataSources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using IDComplete.Interfaces;
using IDComplete.Entities;
using IDComplete.Utilities;
using System.Diagnostics;

namespace IDComplete.CustomControls
{
    public partial class SetupScreen : Form
    {
        IDataSource ColumnSetup;
        IDataSource SheetSetup;
        public SetupScreen(IDataSource columnSetup, IDataSource sheetSetup)
        {
            ColumnSetup = columnSetup;
            SheetSetup = sheetSetup;

            InitializeComponent();
            gridSetup.DataSource = ColumnSetup.GetAllData<List<ColumnSetup>>();

            var sheetSettings = SheetSetup.GetAllData<SheetSetup>();
            txtTriggerCharacter.Text = sheetSettings.TriggerChar;
            txtFirstRow.Text = sheetSettings.FirstRow;

            gridSetup.Columns["CalculationSetup"].Visible = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //check that there is only one primary key column selected
            if (!HasValidPrimaryKey())
            {
                MessageBox.Show("Please ensure that a single column is denoted as the primary key");
            }
            else
            {
                var setupJson = JsonConvert.SerializeObject(gridSetup.DataSource);
                var sheetSetupJson = GetSheetSetupJson();

                if (cbPermanent.Checked)
                {
                    ColumnSetup.Execute(setupJson);
                    SheetSetup.Execute(sheetSetupJson);
                }
                else
                {
                    ColumnSetup.OverrideAllData(setupJson);
                    SheetSetup.OverrideAllData(sheetSetupJson);
                }

                MessageBox.Show("Setup successfully updated");
                this.Hide();
            }
        }
        private string GetSheetSetupJson()
        {
            SheetSetup tempSheetSetup = new SheetSetup();
            tempSheetSetup.TriggerChar = txtTriggerCharacter.Text.Substring(0, 1);
            if (int.TryParse(txtFirstRow.Text, out int newFirstRow))
            {
                tempSheetSetup.FirstRow = txtFirstRow.Text;
            }
            var sheetSetupJson = JsonConvert.SerializeObject(tempSheetSetup);

            return sheetSetupJson;
        }
        private int GetPrimaryKeyColumn()
        {
            int primaryKeyColumn = -1;
            foreach (DataGridViewColumn headerColumn in gridSetup.Columns)
            {
                if (headerColumn.DataPropertyName == "IsPrimaryKey")
                {
                    primaryKeyColumn = headerColumn.Index;
                }
            }

            return primaryKeyColumn;
        }

        private bool HasValidPrimaryKey()
        {
            //checks that there are a primary, and also that there is only one primary key selected
            int primaryKeyColumn = GetPrimaryKeyColumn();

            bool hasPrimaryKey = false;
            foreach (DataGridViewRow row in gridSetup.Rows)
            {
                if ((bool)row.Cells[primaryKeyColumn].Value)
                {
                    if (hasPrimaryKey) { return false; }
                    hasPrimaryKey = true;
                }
            }

            return true;
        }

        private void BtnConfigFileLocation_Click(object sender, EventArgs e)
        {
            var locationToOpen = DataHelpers.ApplicationBaseDirectory + "Configs\\";

            Process.Start(locationToOpen);
        }
    }
}
