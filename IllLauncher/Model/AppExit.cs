using System.Linq;
using System.Windows.Documents;

namespace IllLauncher.Model
{
    public static class AppExit
    {
        public static void ExitApp(AppData appData)
        {
            SaveUserData(appData.UserData);
        }
        private static void SaveUserData(UserData userData)
        {
            if (!userData.HasChanged)
                return;
            JsonHelper.SerializeToFile(userData, ReadonlyData.UserDataFileName);
        }
    }
}
