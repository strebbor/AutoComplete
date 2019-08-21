using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using IDComplete.Interfaces;

namespace IDComplete.DataSources
{
    public class SqlDataSource : IDataSource
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Uri Path { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ConnectionString
        {
            get
            {
                return "Data source = " + Location + "; Initial catalog = " + Name + "; User id = " + Username + "; password = " + Password;
            }
        }

        public string Location { get; set; }

        private object _allData;
        public T GetAllData<T>()
        {
            if (_allData == null)
            {
                Initialise(); //see if we can reload the data
            }

            return (T)Convert.ChangeType(_allData, typeof(T));
        }
        public bool OverrideAllData(object data)
        {
            _allData = data;
            return true;
        }

        public T GetIdentifier<T>()
        {
            throw new NotImplementedException();
        }

        public object Initialise()
        {
            var CreateTablesScriptPath = @"C:\Users\micher03\Source\Repos\IDComplete\Resources\CreateTables.sql";
            var CreatesTablesScript = File.ReadAllText(CreateTablesScriptPath);

            Execute(CreatesTablesScript);

            _allData = Read();

            return true;
        }

        public T Read<T>(object command)
        {
            string commandText = command.ToString();
            DataTable results = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(commandText, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                        {
                            adapter.Fill(results);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

            return (T)Convert.ChangeType(results, typeof(T));
        }

        public object Read()
        {
            string commandText = "SELECT * FROM entries";
            return Read<DataTable>(commandText);
        }

        public object Execute(object command)
        {
            var results = new DataTable();

            string commandText = command.ToString();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(commandText, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                        {
                            adapter.Fill(results);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

            return results;
        }
    }
}
