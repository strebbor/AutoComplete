using IDComplete.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDComplete.Interfaces
{
    public interface IQuery
    {
        string BuildQuery(List<ColumnSetup> setup, ColumnSetup primaryKeyColumn, DataRow dataRow = null);
    }
}
