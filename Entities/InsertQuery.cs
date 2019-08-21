using IDComplete.Interfaces;
using IDComplete.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDComplete.Entities
{
    public class InsertQuery : IQuery
    {
        public string BuildQuery(List<ColumnSetup> setup, ColumnSetup primaryKeyColumn, DataRow dataRow = null)
        {
            StringBuilder fields = new StringBuilder();
            StringBuilder values = new StringBuilder();

            //build the fields and values list
            foreach (ColumnSetup column in setup)
            {
                fields.Append(column.DatabaseColumn + ", ");
                values.Append("'" + dataRow[column.Key] + "', ");
            }

            //convert to strings
            string fieldsList = DataHelpers.CleanQueryString(fields.ToString());
            string valuesList = DataHelpers.CleanQueryString(values.ToString());

            //build the query
            string query = "INSERT INTO Entries (" + fieldsList + ") VALUES (" + valuesList + ") SELECT SCOPE_IDENTITY() AS RowID";
            return query;
        }
    }
}
