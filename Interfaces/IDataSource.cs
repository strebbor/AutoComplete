using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDComplete.Interfaces
{
    public interface IDataSource
    {
        T GetIdentifier<T>();
        T GetAllData<T>();
        string Name { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        Uri Path { get; set; }
        string Location { get; set; }
        string ConnectionString { get; }        
        bool OverrideAllData(object data);
        object Initialise();
        object Execute(object command);
        T Read<T>(object command);
        object Read();
    }
}
