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
    public class SelectQuery : IQuery
    {
        public string BuildQuery(List<ColumnSetup> setup, ColumnSetup primaryKeyColumn, DataRow dataRow = null)
        {
            StringBuilder fields = new StringBuilder();
            string primaryKeyValue = "";

            //build the fields list
            foreach (ColumnSetup column in setup)
            {
                fields.Append(column.DatabaseColumn + " AS " + column.Key + ", ");
                if (column.IsPrimaryKey)
                {
                    primaryKeyValue = dataRow[column.Key].ToString();
                }
            }

            //convert to strings
            string fieldsList = DataHelpers.CleanQueryString(fields.ToString());

            //build the query
            string query = "SELECT " + fieldsList + " FROM entries WHERE " + primaryKeyColumn.DatabaseColumn + " = '" + Security.Encrypt(primaryKeyValue) + "'";
            return query;
        }
    }
}
