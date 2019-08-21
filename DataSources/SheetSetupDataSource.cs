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
    public class SheetSetupDataSource : IDataSource
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Username { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Uri Path { get; set; }

        public string ConnectionString { get => throw new NotImplementedException(); }
        public string Location { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private SheetSetup _allData;

        public object Execute(object command)
        {
            File.WriteAllText(Path.AbsolutePath, command.ToString());
            Initialise();
            return true;
        }

        public T GetAllData<T>()
        {
            return (T)Convert.ChangeType(_allData, typeof(T));
        }

        public T GetIdentifier<T>()
        {
            throw new NotImplementedException();
        }

        public object Initialise()
        {
            var json = Read();
            OverrideAllData(json);
            return true;
        }

        public bool OverrideAllData(object data)
        {
            string jsonData = data.ToString();
            _allData = JsonConvert.DeserializeObject<SheetSetup>(jsonData);
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
    }
}
