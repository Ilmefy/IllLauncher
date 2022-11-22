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
            JsonHelper.SerializeToFile(userData, ReadonlyData.UserDataFileName);
        }
    }
}
