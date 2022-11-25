using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IllLauncher.Model;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;

namespace IllLauncher.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private AppData _appData;
        public MainViewModel()
        {

        }
        public List<GameBase> Games { get { return new List<GameBase>(_appData.UserData.Games); } }
        public List<PublicServer> PublicServers { get {  if (SelectedGame != null) { return new List<PublicServer>(_appData.PublicData.Servers.Where(c => c.Expansion == SelectedGame.Expansion).ToList()); }return new List<PublicServer>(); } }
        public List<UserServer> UserServers { get { if (SelectedGame != null) { return new List<UserServer>(_appData.UserData.Servers.Where(c => c.Expansion == SelectedGame.Expansion).ToList()); } return new List<UserServer>(); } }
        [ObservableProperty]
        ServerBase _selectedServer;
        [ObservableProperty]
        GameBase _selectedGame;
        [ObservableProperty]
        bool _isAnyGameSelected;
        partial void OnSelectedGameChanged(GameBase value)
        {

            OnPropertyChanged(nameof(PublicServers));           
            if (!UserServers.Any())
                return;
            DisplayUserServersTab = true;
            IsAnyGameSelected = true;
            OnPropertyChanged(nameof(UserServers));
        }
        [ObservableProperty]
        Realm _selectedRealm;
        [ObservableProperty]
        bool _displayUserServersTab;
        [ObservableProperty]
        bool _displayUserServers;
        [ObservableProperty]
        bool _displayServers;
        [ObservableProperty]
        bool _displayPublicServers;
        [ObservableProperty]
        bool _displayRealms;

        public MainViewModel(AppData appData)
        {
            _appData = appData;

        }
        [RelayCommand]
        public void AddGame()
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog().Value)
            {

                GameBase gb = GameCreator.CreateGame(dialog.FileName);
                if (gb != null)
                    _appData.UserData.Games.Add(gb);

            }

        }
    }
}
