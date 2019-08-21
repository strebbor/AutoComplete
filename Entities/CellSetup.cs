using IDComplete.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDComplete.Entities
{
    public class ColumnSetup : ICellSetup
    {
        public string Key { get; set; }
        public bool Encrypted { get; set; }
        public string ColumnLetter { get; set; }
        public bool IsPrimaryKey { get; set; }
        public string DatabaseColumn { get; set; }

        public List<ExclusionValues> ValuesToExclude { get; set; }
        public Calculation CalculationSetup { get; set; }

        public int ColumnNumber
        {
            get
            {
                return ColumnLetter
                .Select(c => c - 'A' + 1)
                .Aggregate((sum, next) => sum * 26 + next);
            }
        }
    }

    public class Calculation
    {
        public string Type { get; set; }
        public string FieldToUse { get; set; }

    }

    public class ExclusionValues
    {
        public string Value { get; set; }
    }
}
