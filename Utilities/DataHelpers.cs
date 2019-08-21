using IDComplete.Entities;
using IDComplete.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDComplete.Utilities
{
    public static class DataHelpers
    {
        public static string ApplicationBaseDirectory
        {
            get
            {
                string locationBase = AppDomain.CurrentDomain.BaseDirectory;

                if (!locationBase.EndsWith("\\"))
                {
                    locationBase += "\\";
                }

                return locationBase;
            }
        }

        public static string BuildQuery(IQuery queryType, List<ColumnSetup> columnSetup, DataRow dataRow = null)
        {
            ColumnSetup primaryKeyColumn = new ColumnSetup();

            if (columnSetup.Count < 1)
            {
                NullReferenceException blankException = new NullReferenceException("ColumnSetup cannot be empty");
                throw blankException;
            }

            foreach (ColumnSetup column in columnSetup)
            {
                if (column.IsPrimaryKey)
                {
                    primaryKeyColumn = column;
                }
            }

            if (string.IsNullOrWhiteSpace(primaryKeyColumn.Key))
            {
                NullReferenceException blankException = new NullReferenceException("No PrimaryKey field has been set");
                throw blankException;
            }

            return queryType.BuildQuery(columnSetup, primaryKeyColumn, dataRow);
        }
        public static string CleanQueryString(string stringToClean)
        {
            string cleanString = stringToClean;

            var lastIndexOfComma = stringToClean.LastIndexOf(", ");
            if (lastIndexOfComma > 0)
            {
                cleanString = cleanString.Substring(0, lastIndexOfComma);
            }

            return cleanString;
        }

        public static object DoCalculation(string calculationType, string inputValue)
        {
            ICalculationType calculationToExecute = new AgeCalculation();

            switch (calculationType.ToUpper())
            {
                case "AGECALCULATION":
                    {
                        calculationToExecute = new AgeCalculation();
                    }
                    break;
                case "GENDERCALCULATION":
                    {
                        calculationToExecute = new GenderCalculation();
                    }
                    break;
            }

            return calculationToExecute.execute(inputValue);
        }

        /// <summary>
        /// 1 -> A<br/>
        /// 2 -> B<br/>
        /// 3 -> C<br/>
        /// ...
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static string ExcelColumnFromNumber(int column)
        {
            string columnString = "";
            decimal columnNumber = column;
            while (columnNumber > 0)
            {
                decimal currentLetterNumber = (columnNumber - 1) % 26;
                char currentLetter = (char)(currentLetterNumber + 65);
                columnString = currentLetter + columnString;
                columnNumber = (columnNumber - (currentLetterNumber + 1)) / 26;
            }
            return columnString;
        }


        /// <summary>
        /// A -> 1<br/>
        /// B -> 2<br/>
        /// C -> 3<br/>
        /// ...
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static int NumberFromExcelColumn(string column)
        {
            int retVal = 0;
            string col = column.ToUpper();
            for (int iChar = col.Length - 1; iChar >= 0; iChar--)
            {
                char colPiece = col[iChar];
                int colNum = colPiece - 64;
                retVal = retVal + colNum * (int)Math.Pow(26, col.Length - (iChar + 1));
            }
            return retVal;
        }
    }
}
