using IllLauncher.Model.Extensions;

using System;

namespace IllLauncher.Model
{
    public static class Initializer
    {
        
        public static void Initialize(ref AppData appData)
        {
            GetUserData(ref appData);
        }
        private static void GetUserData(ref AppData appData)
        {
            
            if (ReadonlyData.UserDataFileName.FileExists())
            {
                try
                {
                    appData.UserData = JsonHelper.Deserialize<UserData>(ReadonlyData.UserDataFileName);
                    return;
                }
                catch (Exception)
                {

                }
            }
                appData.UserData = new UserData();
        }
    }
}
