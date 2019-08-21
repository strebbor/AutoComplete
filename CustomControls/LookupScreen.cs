using IDComplete.DataSources;
using IDComplete.Entities;
using IDComplete.Interfaces;
using IDComplete.Utilities;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace IDComplete.CustomControls
{
    public partial class LookupScreen : Form
    {
        public delegate void delRowSelected(List<KeyValuePair<string, string>> rowValues);
        public event delRowSelected RowSelected;

        private string _searchText;
        public string SearchText
        {
            get
            {
                return _searchText;
            }

            set
            {
                _searchText = value;
                SetDataInGrid(_searchText);
            }
        }

        private IDataSource _columnSetupDataSource;
        private DataTable dtLookupData;
        private DataTable _dataSource;
        public LookupScreen(IDataSource columnSetupDataSource, DataTable dataSource)
        {
            _dataSource = dataSource;
            _columnSetupDataSource = columnSetupDataSource;

            InitializeComponent();    
        }
        private void SetDataInGrid(string textToMatch)
        {
            dtLookupData = _dataSource;

            var matches = dtLookupData.Select(_columnSetupDataSource.GetIdentifier<ColumnSetup>().Key + " LIKE '" + textToMatch + "%'");

            DataTable dtFilteredTable = dtLookupData.Clone();
            foreach (DataRow dr in matches)
            {
                dtFilteredTable.ImportRow(dr);
            }
            gridData.DataSource = dtFilteredTable;
        }

        private void GridData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PublishRowSelected();
                Hide();
            }

            if (e.KeyCode == Keys.Escape)
            {
                Hide();
            }
        }

        private void PublishRowSelected()
        {
            List<KeyValuePair<string, string>> responseObjects = new List<KeyValuePair<string, string>>();

            if (gridData.Rows.Count > 0)
            {
                foreach (var cell in gridData.CurrentRow.Cells)
                {
                    var cellObject = (DataGridViewTextBoxCell)cell;
                    var key = gridData.Columns[cellObject.ColumnIndex].DataPropertyName;
                    var value = cellObject.Value.ToString();

                    KeyValuePair<string, string> cellValue = new KeyValuePair<string, string>(key, value);
                    responseObjects.Add(cellValue);
                }

                RowSelected(responseObjects);
            }
        }

        private void GridData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PublishRowSelected();
            Hide();
        }
    }
}
