using NUnit.Framework;
using IDComplete.Utilities;
using IDComplete.Entities;
using System.Collections.Generic;
using System;
using System.Data;

namespace Tests
{
    public class DataHelpersTests
    {
        [Test]
        public void BuildQuery_With_Four_Columns_Select()
        {
            var setup = GetFourColumnSetup();

            DataRow dr = GetFourColumnTable().NewRow();
            dr["IDNumber"] = "123456";
            dr["FirstName"] = "firstname of person";
            dr["LastName"] = "lastname of person";
            dr["Surname"] = "suranme of person";


            var results = DataHelpers.BuildQuery(new SelectQuery(), setup, dr);
            var expected = "SELECT IDNumber AS IDNumber, FirstName AS FirstName, LastName AS LastName, Surname AS Surname FROM entries WHERE IDNumber = '123456'";

            Assert.IsTrue(results == expected);
        }

        [Test]
        public void BuildQuery_With_Four_Columns_Insert()
        {
            var setup = GetFourColumnSetup();

            DataRow dr = GetFourColumnTable().NewRow();
            dr["IDNumber"] = "123456";
            dr["FirstName"] = "firstname of person";
            dr["LastName"] = "lastname of person";
            dr["Surname"] = "suranme of person";

            var results = DataHelpers.BuildQuery(new InsertQuery(), setup, dr);
            var expected = "INSERT INTO Entries (IDNumber, FirstName, LastName, Surname) VALUES ('123456', 'firstname of person', 'lastname of person', 'suranme of person') SELECT SCOPE_IDENTITY() AS RowID";

            Assert.IsTrue(results == expected);
        }

        [Test]
        public void BuildQuery_With_Four_Columns_Update()
        {
            var setup = GetFourColumnSetup();

            DataRow dr = GetFourColumnTable().NewRow();
            dr["IDNumber"] = "123456";
            dr["FirstName"] = "firstname of person";
            dr["LastName"] = "lastname of person";
            dr["Surname"] = "suranme of person";

            var results = DataHelpers.BuildQuery(new UpdateQuery(), setup, dr);
            var expected = "UPDATE Entries SET IDNumber = '123456', FirstName = 'firstname of person', LastName = 'lastname of person', Surname = 'suranme of person' WHERE IDNumber = '123456' SELECT SCOPE_IDENTITY() AS RowID";

            Assert.IsTrue(results == expected);
        }

        [Test]
        public void BuildQuery_With_Zero_Columns_Select()
        {
            var setup = new List<ColumnSetup>();

            DataRow dr = GetFourColumnTable().NewRow();

            var ex = Assert.Throws<NullReferenceException>(
            delegate
            { var results = DataHelpers.BuildQuery(new SelectQuery(), setup, dr); }
            );
            Assert.That(ex.Message, Is.EqualTo("ColumnSetup cannot be empty"));
        }

        [Test]
        public void BuildQuery_With_Zero_Columns_Insert()
        {
            var setup = new List<ColumnSetup>();

            DataRow dr = GetFourColumnTable().NewRow();
            dr["IDNumber"] = "123456";
            dr["FirstName"] = "firstname of person";
            dr["LastName"] = "lastname of person";
            dr["Surname"] = "suranme of person";

            var ex = Assert.Throws<NullReferenceException>(
            delegate
            { var results = DataHelpers.BuildQuery(new InsertQuery(), setup, dr); }
            );
            Assert.That(ex.Message, Is.EqualTo("ColumnSetup cannot be empty"));
        }

        [Test]
        public void BuildQuery_With_Zero_Columns_Update()
        {
            var setup = new List<ColumnSetup>();

            DataRow dr = GetFourColumnTable().NewRow();
            dr["IDNumber"] = "123456";
            dr["FirstName"] = "firstname of person";
            dr["LastName"] = "lastname of person";
            dr["Surname"] = "suranme of person";

            var ex = Assert.Throws<NullReferenceException>(
            delegate
            { var results = DataHelpers.BuildQuery(new UpdateQuery(), setup, dr); }
            );
            Assert.That(ex.Message, Is.EqualTo("ColumnSetup cannot be empty"));
        }

        [Test]
        public void BuildQuery_With_No_PrimaryKey_Select()
        {
            var setup = GetFourColumnSetup();

            DataRow dr = GetFourColumnTable().NewRow();
            dr["IDNumber"] = "123456";
            dr["FirstName"] = "firstname of person";
            dr["LastName"] = "lastname of person";
            dr["Surname"] = "suranme of person";

            setup[0].IsPrimaryKey = false;

            var ex = Assert.Throws<NullReferenceException>(
            delegate { var results = DataHelpers.BuildQuery(new SelectQuery(), setup, dr); });
            Assert.That(ex.Message, Is.EqualTo("No PrimaryKey field has been set"));
        }

        [Test]
        public void BuildQuery_With_No_PrimaryKey_Insert()
        {
            var setup = GetFourColumnSetup();

            DataRow dr = GetFourColumnTable().NewRow();
            dr["IDNumber"] = "123456";
            dr["FirstName"] = "firstname of person";
            dr["LastName"] = "lastname of person";
            dr["Surname"] = "suranme of person";

            setup[0].IsPrimaryKey = false;

            var ex = Assert.Throws<NullReferenceException>(
            delegate { var results = DataHelpers.BuildQuery(new InsertQuery(), setup, dr); });
            Assert.That(ex.Message, Is.EqualTo("No PrimaryKey field has been set"));
        }


        [Test]
        public void BuildQuery_With_No_PrimaryKey_Update()
        {
            var setup = GetFourColumnSetup();

            DataRow dr = GetFourColumnTable().NewRow();
            dr["IDNumber"] = "123456";
            dr["FirstName"] = "firstname of person";
            dr["LastName"] = "lastname of person";
            dr["Surname"] = "suranme of person";

            setup[0].IsPrimaryKey = false;

            var ex = Assert.Throws<NullReferenceException>(
            delegate { var results = DataHelpers.BuildQuery(new UpdateQuery(), setup, dr); });
            Assert.That(ex.Message, Is.EqualTo("No PrimaryKey field has been set"));
        }

        [Test]
        public void BuildQuery_With_Blank_valueToQuery_Select()
        {
            var setup = GetFourColumnSetup();

            DataRow dr = GetFourColumnTable().NewRow();
            dr["IDNumber"] = "";
            dr["FirstName"] = "firstname of person";
            dr["LastName"] = "lastname of person";
            dr["Surname"] = "suranme of person";

            var results = DataHelpers.BuildQuery(new SelectQuery(), setup, dr);
            var expected = "SELECT IDNumber AS IDNumber, FirstName AS FirstName, LastName AS LastName, Surname AS Surname FROM entries WHERE IDNumber = ''";

            Assert.IsTrue(results == expected);
        }

        [Test]
        public void BuildQuery_With_Blank_valueToQuery_Insert()
        {
            var setup = GetFourColumnSetup();

            DataRow dr = GetFourColumnTable().NewRow();
            dr["IDNumber"] = "";
            dr["FirstName"] = "firstname of person";
            dr["LastName"] = "lastname of person";
            dr["Surname"] = "suranme of person";

            var results = DataHelpers.BuildQuery(new InsertQuery(), setup, dr);
            var expected = "INSERT INTO Entries (IDNumber, FirstName, LastName, Surname) VALUES ('', 'firstname of person', 'lastname of person', 'suranme of person') SELECT SCOPE_IDENTITY() AS RowID";

            Assert.IsTrue(results == expected);
        }

        [Test]
        public void BuildQuery_With_Blank_valueToQuery_Update()
        {
            var setup = GetFourColumnSetup();

            DataRow dr = GetFourColumnTable().NewRow();
            dr["IDNumber"] = "";
            dr["FirstName"] = "firstname of person";
            dr["LastName"] = "lastname of person";
            dr["Surname"] = "suranme of person";

            var results = DataHelpers.BuildQuery(new UpdateQuery(), setup, dr);
            var expected = "UPDATE Entries SET IDNumber = '', FirstName = 'firstname of person', LastName = 'lastname of person', Surname = 'suranme of person' WHERE IDNumber = '' SELECT SCOPE_IDENTITY() AS RowID";

            Assert.IsTrue(results == expected);
        }

        [Test]
        public void BuildQuery_With_Null_valueToQuery_Select()
        {
            var setup = GetFourColumnSetup();

            DataRow dr = GetFourColumnTable().NewRow();
            dr["IDNumber"] = null;
            dr["FirstName"] = "firstname of person";
            dr["LastName"] = "lastname of person";
            dr["Surname"] = "suranme of person";

            var results = DataHelpers.BuildQuery(new SelectQuery(), setup, dr);
            var expected = "SELECT IDNumber AS IDNumber, FirstName AS FirstName, LastName AS LastName, Surname AS Surname FROM entries WHERE IDNumber = ''";

            Assert.IsTrue(results == expected);
        }

        [Test]
        public void BuildQuery_With_Null_valueToQuery_Insert()
        {
            var setup = GetFourColumnSetup();

            DataRow dr = GetFourColumnTable().NewRow();
            dr["IDNumber"] = null;
            dr["FirstName"] = "firstname of person";
            dr["LastName"] = "lastname of person";
            dr["Surname"] = "suranme of person";

            var results = DataHelpers.BuildQuery(new InsertQuery(), setup, dr);
            var expected = "INSERT INTO Entries (IDNumber, FirstName, LastName, Surname) VALUES ('', 'firstname of person', 'lastname of person', 'suranme of person') SELECT SCOPE_IDENTITY() AS RowID";

            Assert.IsTrue(results == expected);
        }

        [Test]
        public void BuildQuery_With_Null_valueToQuery_Update()
        {
            var setup = GetFourColumnSetup();

            DataRow dr = GetFourColumnTable().NewRow();
            dr["IDNumber"] = null;
            dr["FirstName"] = "firstname of person";
            dr["LastName"] = "lastname of person";
            dr["Surname"] = "suranme of person";

            var results = DataHelpers.BuildQuery(new UpdateQuery(), setup, dr);
            var expected = "UPDATE Entries SET IDNumber = '', FirstName = 'firstname of person', LastName = 'lastname of person', Surname = 'suranme of person' WHERE IDNumber = '' SELECT SCOPE_IDENTITY() AS RowID";
            
            Assert.IsTrue(results == expected);
        }

        public void ToDo()
        {
            //add tests to see what happens if the DB column and the column key is different
            //and if there is not db column specified or no key specified
        }

        [Test]
        public void ExcelColumnFromNumber_Valid_Data()
        {
            var results = DataHelpers.ExcelColumnFromNumber(5);
            var expected = "E";

            Assert.IsTrue(results == expected);
        }

        [Test]
        public void ExcelColumnFromNumber_Mid_Number()
        {
            var results = DataHelpers.ExcelColumnFromNumber(27);
            var expected = "AA";
            Assert.IsTrue(results == expected);
        }

        [Test]
        public void ExcelColumnFromNumber_Large_Number()
        {
            var results = DataHelpers.ExcelColumnFromNumber(879);
            var expected = "AGU";
            Assert.IsTrue(results == expected);
        }

        [Test]
        public void NumberFromExcelColumn_Valid_Data()
        {
            var results = DataHelpers.NumberFromExcelColumn("E");
            var expected = 5;

            Assert.IsTrue(results == expected);
        }

        [Test]
        public void NumberFromExcelColumnr_Mid_Number()
        {
            var results = DataHelpers.NumberFromExcelColumn("AA");
            var expected = 27;
            Assert.IsTrue(results == expected);
        }

        [Test]
        public void NumberFromExcelColumn_Large_Number()
        {
            var results = DataHelpers.NumberFromExcelColumn("AGU");
            var expected = 879;
            Assert.IsTrue(results == expected);
        }

        [Test]
        public void NumberFromExcelColumn_LowerCase()
        {
            var results = DataHelpers.NumberFromExcelColumn("b");
            var expected = 2;
            Assert.IsTrue(results == expected);
        }

        [Test]
        public void NumberFromExcelColumn_MixedCase()
        {
            var results = DataHelpers.NumberFromExcelColumn("aGu");
            var expected = 879;
            Assert.IsTrue(results == expected);
        }

        private DataTable GetFourColumnTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IDNumber");
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("Surname");

            return dt;
        }

        private List<ColumnSetup> GetFourColumnSetup()
        {
            ColumnSetup col1 = new ColumnSetup() { DatabaseColumn = "IDNumber", Key = "IDNumber", IsPrimaryKey = true };
            ColumnSetup col2 = new ColumnSetup() { DatabaseColumn = "FirstName", Key = "FirstName" };
            ColumnSetup col3 = new ColumnSetup() { DatabaseColumn = "LastName", Key = "LastName" };
            ColumnSetup col4 = new ColumnSetup() { DatabaseColumn = "Surname", Key = "Surname" };
            var columnSetup = new List<ColumnSetup>();
            columnSetup.Add(col1);
            columnSetup.Add(col2);
            columnSetup.Add(col3);
            columnSetup.Add(col4);

            return columnSetup;
        }
    }
}