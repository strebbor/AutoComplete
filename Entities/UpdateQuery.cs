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
    public class UpdateQuery : IQuery
    {
        public string BuildQuery(List<ColumnSetup> setup, ColumnSetup primaryKeyColumn, DataRow dataRow = null)
        {
            StringBuilder values = new StringBuilder();
            string primaryKeyValue = "";

            //build the fields and values list
            foreach (ColumnSetup column in setup)
            {
                values.Append(column.DatabaseColumn + " = '" + dataRow[column.Key] + "', ");
                if (column.IsPrimaryKey)
                {
                    primaryKeyValue = dataRow[column.Key].ToString();
                }
            }

            //convert to strings          
            string valuesList = DataHelpers.CleanQueryString(values.ToString());

            //build the query            
            string query = "UPDATE Entries SET " + valuesList + " WHERE " + primaryKeyColumn.DatabaseColumn + " = '" + primaryKeyValue + "' SELECT SCOPE_IDENTITY() AS RowID";
            return query;
        }
    }
}
