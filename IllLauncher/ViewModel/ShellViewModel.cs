

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using IllLauncher.Model;


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
            if (string.Equals(_selectedMenuItem, val))
                return;
            switch(val)
            {
                case "Main":
                    _selectedViewModel=new MainViewModel(AppData);break;
            }
        }
        public ShellViewModel()
        {
            Initializer.Initialize(ref AppData);
            //Use default ViewModel
            
            WrathOfTheLichKingGame wotlk = new WrathOfTheLichKingGame(@"D:\World of Warcraft - Wrath of The Lich King 3.3.5a\Sunwell.pl-World-of-Warcraft-Win-LegionRemaster\World of Warcraft\Wow.exe");

        }
    }
}
