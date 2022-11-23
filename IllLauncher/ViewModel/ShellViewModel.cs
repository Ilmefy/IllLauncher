using IllLauncher.Model;

using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace IllLauncher.ViewModel
{
    public partial class ShellViewModel:ObservableObject
    {
        public AppData AppData = new AppData();
        [ObservableProperty]
        ObservableObject _selectedViewModel;
        [ObservableProperty]
        string[] _menuItems = { "Main" };
        public ShellViewModel()
        {
            Initializer.Initialize(ref AppData);
            //Use default ViewModel
            _selectedViewModel = new MainViewModel(AppData);

        }
    }
}
