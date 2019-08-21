using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDComplete.Entities
{
    public class ApplicationSetup
    {
        public void Initialise(Uri setupLocation)
        {
            var appSetupJSON = File.ReadAllText(setupLocation.AbsolutePath);

            var setup = JsonConvert.DeserializeObject<ApplicationSetup>(appSetupJSON);
            DatabaseUsername = setup.DatabaseUsername;
            DatabasePassword = setup.DatabasePassword;
            DatabaseName = setup.DatabaseName;
            DatabaseLocation = setup.DatabaseLocation;
        }
        public string DatabaseUsername { get; set; }
        public string DatabasePassword { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseLocation { get; set; }
    }
}