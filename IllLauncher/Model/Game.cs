using IllLauncher.Model;

using Newtonsoft.Json;

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Xps.Serialization;

namespace IllLauncher.Model
{

    public abstract class GameBase : ITrackPropertyChange, IInitialize
    {
        public int Id { get; protected set; }
        #region Name
        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.Equals(_name, value)) return;
                string oldValue = _name;
                _name = value;
                NameChangedEvent?.Invoke(this, new DefaultEventArgs(value, oldValue));
                HasChanged = true;
            }
        }
        public delegate void NameChangedHandler(object sender, DefaultEventArgs e);
        public event NameChangedHandler NameChangedEvent;
        #endregion
        #region GameLauncherFileName
        private string _gameLauncherFileName = string.Empty;
        public string GameLauncherFileName
        {
            get { return _gameLauncherFileName; }
            set
            {
                if (string.Equals(_gameLauncherFileName, value)) return;
                string oldValue = _gameLauncherFileName;
                _gameLauncherFileName = value;
                GameLauncherFileNameChangedEvent?.Invoke(this, new DefaultEventArgs(value, oldValue));
                HasChanged = true;
            }
        }
        public delegate void GameLauncherFileNameChangedHandler(object sender, DefaultEventArgs e);
        public event GameLauncherFileNameChangedHandler GameLauncherFileNameChangedEvent;
        #endregion
        public Expansion Expansion { get; protected set; }

        public bool HasChanged { get; protected set; }
        protected string GameDirectory { get; set; } = string.Empty;
        protected string AddonsDirectory { get; set; } = string.Empty;
        protected string CacheDirectory { get; set; } = string.Empty;
        protected string WTFDirectory { get; set; } = string.Empty;
        protected FileVersionInfo GameLauncherFileVersionInfo { get; set; }
        protected abstract bool SetRealmlist(string realmlist);
        protected abstract bool SetRealmlist(ServerBase server);
        protected abstract bool SetRealmlist(Realm realm);
        public abstract Process StartGame(string newRealmlist = null);
        public abstract Process StartGame(ServerBase server);
        public abstract Process StartGame(Realm realm);
        
        public static Expansion GetExpansion(string fileName)
        {
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(fileName);
            return (Expansion)int.Parse(fileVersionInfo.FileVersion[0].ToString());
        }
        public abstract Task Initialize();
    }
    public abstract class PreMopGame : GameBase
    {
        #region Properties
        protected string RealmlistFileName { get; set; } = string.Empty;
        #endregion
        #region Constructors
        public PreMopGame()
        {
        }
        public PreMopGame(string fileName, bool initializeAtCreate = true)
        {
            GameLauncherFileName= fileName;
            if(initializeAtCreate)
                Task.Factory.StartNew(()=>Initialize());
        }
        #endregion
        #region Methods
        public override async Task Initialize()
        {
            GameLauncherFileVersionInfo = FileVersionInfo.GetVersionInfo(GameLauncherFileName);
            Expansion = (Expansion)(int.Parse(GameLauncherFileVersionInfo.FileVersion[0].ToString())) + 1;
            GameDirectory = Path.GetDirectoryName(GameLauncherFileName);
            AddonsDirectory = Directory.GetDirectories(GameDirectory, "Addons", SearchOption.AllDirectories).First();
            CacheDirectory = Directory.GetDirectories(GameDirectory, "Cache", SearchOption.AllDirectories).First(); ;
            WTFDirectory = Directory.GetDirectories(GameDirectory, "WTF", SearchOption.AllDirectories).First(); 
        }
        #region StartGame
        public override Process StartGame(Realm realm)
        {
            throw new NotImplementedException();
        }
        public override Process StartGame(ServerBase server)
        {
            throw new NotImplementedException();
        }
        public override Process StartGame(string newRealmlist = null)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion




        protected override bool SetRealmlist(string realmlist)
        {
            if (string.IsNullOrEmpty(RealmlistFileName))
                if (File.Exists(RealmlistFileName))
                {
                    try
                    {
                        File.SetAttributes(RealmlistFileName, System.IO.FileAttributes.Normal);
                        File.WriteAllText(RealmlistFileName, realmlist);
                        File.SetAttributes(RealmlistFileName, System.IO.FileAttributes.ReadOnly);
                        return true;
                    }
                    catch (Exception)
                    {
                    }
                }
            return false;
        }
        protected override bool SetRealmlist(Realm realm) => SetRealmlist(realm.Realmlist);
        protected override bool SetRealmlist(ServerBase server) => SetRealmlist(server.Realmlist);
    }
    //public class VanillaGame : PreMopGame
    //{
    //    public VanillaGame() { }
    //    public VanillaGame(string fileName) : base(fileName) { }
    //}
    //public class TheBurningCrusadeGame : PreMopGame
    //{
    //    public TheBurningCrusadeGame() { }
    //    public TheBurningCrusadeGame(string fileName) : base(fileName) { }

    public class WrathOfTheLichKingGame : PreMopGame
    {
        public WrathOfTheLichKingGame() { }
        public WrathOfTheLichKingGame(string fileName) : base(fileName) { }

    }
}
    //public class CataclysmGame : PreMopGame
    //{
    //    public CataclysmGame() { }
    //    public CataclysmGame(string fileName) : base(fileName) { }
    //}


