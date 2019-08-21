using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDComplete.Interfaces
{
    public interface ICellSetup
    {
        string Key { get; set; }
        string ColumnLetter { get; set; }
        bool IsPrimaryKey { get; set; }
    }
}
