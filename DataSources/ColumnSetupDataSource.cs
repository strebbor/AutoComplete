using IDComplete.Entities;
using IDComplete.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDComplete.DataSources
{
    public class ColumnSetupDataSource : IDataSource
    {
        public string Name { get; set; }
        public string Username { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Uri Path { get; set; }
        public string ConnectionString { get => throw new NotImplementedException(); }
        public string Location { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private List<ColumnSetup> _allData;

        public T GetAllData<T>()
        {
            return (T)Convert.ChangeType(_allData, typeof(T));
        }
        public bool OverrideAllData(object data)
        {
            string jsonData = data.ToString();
            _allData = JsonConvert.DeserializeObject<List<ColumnSetup>>(jsonData);
            return true;
        }

        public T GetIdentifier<T>()
        {
            var match = _allData.Find(x => x.IsPrimaryKey);
            return (T)Convert.ChangeType(match, typeof(T));
        }

        public object Initialise()
        {
            var json = Read();
            OverrideAllData(json);
            return true;
        }

        public T Read<T>(object command)
        {
            throw new NotImplementedException();
        }

        public object Read()
        {
            string json = "";

            using (StreamReader r = new StreamReader(Path.AbsolutePath))
            {
                json = r.ReadToEnd();
            }

            return json;
        }
        public object Execute(object command)
        {
            File.WriteAllText(Path.AbsolutePath, command.ToString());
            Initialise();
            return true;
        }
    }
}
