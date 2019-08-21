using IDComplete.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDComplete.Entities
{
    public class AgeCalculation : ICalculationType
    {
        public object execute(string inputValue)
        {
            if (string.IsNullOrWhiteSpace(inputValue))
            {
                return "";
            }

            if (inputValue.Length < 13)
            {
                return "";
            }

            //get the first two characters of the ID number
            var birthYearShort = inputValue.Substring(0, 2); //2002
            var currentYear = DateTime.Now.Year;

            if (int.Parse(birthYearShort) <= int.Parse(currentYear.ToString().Substring(2)))
            {
                return currentYear - int.Parse("20" + birthYearShort);
            }
            else
            {
                return currentYear - int.Parse("19" + birthYearShort);
            }
        }
    }
}
