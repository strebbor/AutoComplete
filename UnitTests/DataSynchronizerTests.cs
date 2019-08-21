using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using IDComplete.Utilities;
using IDComplete.Entities;
using IDComplete.Interfaces;
using System.Data;
using IDComplete.DataSources;
using Newtonsoft.Json;

namespace Tests
{
    public class DataSynchronizerTests
    {
        [Test]
        public void AreRowsDifferent_With_No_Changes()
        {
            IDataSource columnSetup = new ColumnSetupDataSource();
            columnSetup.OverrideAllData(JsonConvert.SerializeObject(GetFourColumnSetup()));
            DataSyncLogic syncer = new DataSyncLogic(columnSetup, null);

            var row1 = GetDefaultRow();

            var results = syncer.AreRowsDifferent(row1, row1);
            var expected = false;

            Assert.IsTrue(results == expected);
        }

        [Test]
        public void AreRowsDifferent_With_Changes()
        {
            IDataSource columnSetup = new ColumnSetupDataSource();
            columnSetup.OverrideAllData(JsonConvert.SerializeObject(GetFourColumnSetup()));
            DataSyncLogic syncer = new DataSyncLogic(columnSetup, null);

            var row1 = GetDefaultRow();
            var row2 = GetDefaultRow();
            row2[0] = "changedvalue";

            var results = syncer.AreRowsDifferent(row1, row2);
            var expected = true;

            Assert.IsTrue(results == expected);
        }

        [Test]
        public void AreRowsDifferent_With_No_Changes_Except_For_Casing()
        {
            IDataSource columnSetup = new ColumnSetupDataSource();
            columnSetup.OverrideAllData(JsonConvert.SerializeObject(GetFourColumnSetup()));
            DataSyncLogic syncer = new DataSyncLogic(columnSetup, null);

            var row1 = GetDefaultRow();
            var row2 = GetDefaultRow();
            row2[0] = row2[0].ToString().ToUpper();

            var results = syncer.AreRowsDifferent(row1, row2);
            var expected = false;

            Assert.IsTrue(results == expected);
        }

        private DataRow GetDefaultRow()
        {
            DataRow testRow = GetDefaultTable().NewRow();
            testRow[0] = "firstvalue";
            testRow[1] = "secondvalue";
            testRow[2] = "thirdvalue";
            testRow[3] = "fourthvalue";

            return testRow;
        }

        private DataTable GetDefaultTable()
        {
            DataTable testTable = new DataTable();
            testTable.Columns.Add("FirstColumn");
            testTable.Columns.Add("SecondColumn");
            testTable.Columns.Add("ThirdColumn");
            testTable.Columns.Add("FourthColumn");

            return testTable;
        }

        private List<ColumnSetup> GetFourColumnSetup()
        {
            ColumnSetup col1 = new ColumnSetup() { DatabaseColumn = "FirstColumn", Key = "FirstColumn", IsPrimaryKey = true, ColumnLetter = "A" };
            ColumnSetup col2 = new ColumnSetup() { DatabaseColumn = "SecondColumn", Key = "SecondColumn", ColumnLetter = "B" };
            ColumnSetup col3 = new ColumnSetup() { DatabaseColumn = "ThirdColumn", Key = "ThirdColumn", ColumnLetter = "C" };
            ColumnSetup col4 = new ColumnSetup() { DatabaseColumn = "FourthColumn", Key = "FourthColumn", ColumnLetter = "D" };
            var columnSetup = new List<ColumnSetup>();
            columnSetup.Add(col1);
            columnSetup.Add(col2);
            columnSetup.Add(col3);
            columnSetup.Add(col4);

            return columnSetup;
        }
    }
}
