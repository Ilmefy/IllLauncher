using CommunityToolkit.Mvvm.ComponentModel;
using IllLauncher.Model;



namespace IllLauncher.ViewModel
{
    public partial class MainViewModel:ObservableObject
    {
        private AppData _appData;
        public MainViewModel()
        {
            
        }
        public MainViewModel( AppData appData)
        {
            _appData= appData;
            appData.UserData.Servers[0].Name = "HEHEHHEHE";
            
        }
    }
}
