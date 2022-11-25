

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using IllLauncher.Model;

using System.Collections.Generic;

namespace IllLauncher.ViewModel
{
    public partial class ShellViewModel:ObservableObject
    {
        
        public AppData AppData = new AppData();
        [ObservableProperty]
        ObservableObject _selectedViewModel;
        [ObservableProperty]
        string _selectedMenuItem;
        [ObservableProperty]
        string[] _menuItems = { "Main" };
        partial void OnSelectedMenuItemChanged(string value)=>SetView(value);
        private void SetView(string val)
        {
            //if (string.Equals(_selectedMenuItem, val))
            //    return;
            switch(val)
            {
                case "Main":
                    SelectedViewModel=new MainViewModel(AppData);break;
            }
        }
        public ShellViewModel()
        {
            Initializer.Initialize(ref AppData);
            //Use default ViewModel
            SelectedViewModel = new MainViewModel(AppData); 

            WrathOfTheLichKingGame wotlk = new WrathOfTheLichKingGame(@"D:\World of Warcraft - Wrath of The Lich King 3.3.5a\Sunwell.pl-World-of-Warcraft-Win-LegionRemaster\World of Warcraft\Wow.exe");
            AppData.UserData.Games.Add(wotlk);
            AppData.UserData.Servers = TESTCLASS.GenerateUserServers(10, Expansion.WrathOfTheLichKing);
            AppData.UserData.Servers.AddRange(TESTCLASS.GenerateUserServers(10, Expansion.Cataclysm));
        }
        [RelayCommand]
        public void ExitApp()
        {
            AppExit.ExitApp(AppData);
        }
    }
}
