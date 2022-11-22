using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IllLauncher.Model
{
    public static class ReadonlyData
    {
        public static string AppDataDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}//IllLauncher";
        public static string UserDataFileName = $"{AppDataDirectory}//UserData.json";
    }
}
