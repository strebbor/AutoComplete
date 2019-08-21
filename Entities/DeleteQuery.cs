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
    public class DeleteQuery : IQuery
    {
        public string BuildQuery(List<ColumnSetup> setup, ColumnSetup primaryKeyColumn, DataRow dataRow = null)
        {
            //build the query
            string query = "DELETE FROM Entries WHERE " + primaryKeyColumn.DatabaseColumn + " = '" + dataRow[primaryKeyColumn.Key].ToString() + "'";
            return query;
        }
    }
}
