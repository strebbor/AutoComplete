using IDComplete.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDComplete.Entities
{
    public class GenderCalculation : ICalculationType
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
            var genderRange = int.Parse(inputValue.Substring(6, 4));

            var gender = "M";
            if (genderRange <= 4999)
            {
                gender = "F";
            }

            return gender;
        }
    }

}
