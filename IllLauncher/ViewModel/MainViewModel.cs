using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using IllLauncher.Model;

using Microsoft.Win32;

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
    
        }
        [RelayCommand]
        public void AddGame()
        {
            var dialog = new OpenFileDialog();
            
            if(dialog.ShowDialog().Value)
            {

              GameBase gb= GameCreator.CreateGame(dialog.FileName);
                if (gb != null)
                    _appData.UserData.Games.Add(gb);
                
            }
            
        }
    }
}
