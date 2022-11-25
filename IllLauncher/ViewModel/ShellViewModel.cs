

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using IllLauncher.Model;

using System.Collections.Generic;

namespace IllLauncher.ViewModel
{
    public partial class ShellViewModel:ObservableObject
    {

        public AppData AppData;
        
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
             AppData=  new AppData();
            //Use default ViewModel
            SelectedViewModel = new MainViewModel(AppData);




        }
        [RelayCommand]
        public void ExitApp()
        {
            AppExit.ExitApp(AppData);
        }
    }
}
