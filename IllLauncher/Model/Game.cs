using Newtonsoft.Json;

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace IllLauncher.Model
{

    public abstract class GameBase : ITrackPropertyChange
    {
        public int Id { get; protected set; }
        public void SetId(int id, bool acceptChange = false)
        {
            if (Id == id) return;
            Id = id;
            if (!acceptChange) HasChanged = true;
        }
        #region Name
        [JsonIgnore]
        private string _name;
        public string Name
        {
            get { return _name; }
            set { string oldValue = _name; _name = value; NameChanged?.Invoke(this, new DefaultEventArgs(value, oldValue)); }
        }
        public delegate void NameChangedHandler(object sender, DefaultEventArgs e);
        public event NameChangedHandler NameChanged;
        public void SetName(string name, bool acceptChange = false)
        {
            if (Name == name) return;
            Name = name;
            if (!acceptChange) HasChanged = true;
        }
        #endregion

        #region GameLauncherFileName
        private string _gameLauncherFileName = "";
        public string GameLauncherFileName
        {
            get { return _gameLauncherFileName; }
            set { string oldValue = _gameLauncherFileName; _gameLauncherFileName = value; GameLauncherChanged?.Invoke(this, new DefaultEventArgs(value, oldValue)); }
        }
        public void SetGameLauncherFileName(string filename, bool acceptChange = false)
        {
            if (GameLauncherFileName == filename) return;
            GameLauncherFileName = filename;
            if (!acceptChange) HasChanged = true;
        }
        public delegate void GameLauncherChangedHandler(object sender, DefaultEventArgs e);
        public event GameLauncherChangedHandler GameLauncherChanged;
        private void GameBase_GameLauncherChanged1(object sender, DefaultEventArgs e)
        {
            Initialize(e.NewValue.ToString());
        }
        #endregion

        [JsonIgnore]
        public Expansion Expansion { get; protected set; }
        [JsonIgnore]
        public bool HasChanged { get; protected set; }

        #region CustomGameLauncher
        private string _customGameLauncherFileName;

        public string CustomGameLauncherFileName
        {
            get { return _customGameLauncherFileName; }
            set { string oldValue = _customGameLauncherFileName; _customGameLauncherFileName = value; CustomGameLauncherFileNameChanged?.Invoke(null, new DefaultEventArgs(value, oldValue)); }
        }
        public delegate void CustomGameLauncherFileNameChangedHandler(object sender, DefaultEventArgs e);
        public event CustomGameLauncherFileNameChangedHandler CustomGameLauncherFileNameChanged;
        #endregion
        protected string GameDirectory { get; set; } = "";
        protected string AddonsDirectory { get; set; } = "";
        protected string CacheDirectory { get; set; } = "";
        protected string WTFDirectory { get; set; } = "";
        protected FileVersionInfo GameLauncherFileVersionInfo { get; set; }
        protected virtual void SetRealmlist(string realmlist) { }
        protected void SetRealmlist(ServerBase server) => SetRealmlist(server.Realmlist);
        protected void SetRealmlist(Realm realm) => SetRealmlist(realm.Realmlist);
        public virtual Process StartGame()
        {

            return Process.Start(new ProcessStartInfo(GameLauncherFileName));
        }
        public static Expansion GetExpansion(string fileName)
        {
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(fileName);
            return (Expansion)int.Parse(fileVersionInfo.FileVersion[0].ToString());
        }
        protected virtual void Initialize(string fileName)
        {
            
            GameLauncherFileVersionInfo = FileVersionInfo.GetVersionInfo(GameLauncherFileName);
            Expansion = (Expansion)(int.Parse(GameLauncherFileVersionInfo.FileVersion[0].ToString())) + 1;
            GameDirectory = Path.GetDirectoryName(GameLauncherFileName);
            AddonsDirectory = Directory.GetDirectories(GameDirectory, "Addons", SearchOption.AllDirectories).First();
            CacheDirectory = Directory.GetDirectories(GameDirectory, "Cache", SearchOption.AllDirectories).First(); ;
            WTFDirectory = Directory.GetDirectories(GameDirectory, "WTF", SearchOption.AllDirectories).First(); ;

        }
        public GameBase()
        {
            //TRZEBA PRZEPISAĆ WSZYSTKIE PROPERTY. Obecnie dane się nie inicjalizują jeśli zostaną odczytane z pliku JSON (Initialize() nie jest uruchamiane w GameBase())
            GameLauncherChanged += GameBase_GameLauncherChanged1;
        }



        public GameBase(string fileName) : base()
        {
            GameLauncherFileName = fileName;
            HasChanged = true;
        }
    }
    public abstract class PreMopGame : GameBase
    {

        protected string RealmlistFileName { get; set; } = "";
        public PreMopGame() { }
        public PreMopGame(string fileName) : base(fileName) { }
        protected override void SetRealmlist(string realmlist)
        {
            if (string.IsNullOrEmpty(RealmlistFileName))
                if (File.Exists(RealmlistFileName))
                {
                    File.SetAttributes(RealmlistFileName, System.IO.FileAttributes.Normal);
                    File.WriteAllText(RealmlistFileName, realmlist);
                    File.SetAttributes(RealmlistFileName, System.IO.FileAttributes.ReadOnly);
                }
        }
        protected override void Initialize(string fileName)
        {
            base.Initialize(fileName);
            RealmlistFileName = Directory.GetFiles(GameDirectory, "Realmlist.wtf", SearchOption.AllDirectories).First();
        }


    }
    public class VanillaGame : PreMopGame
    {
        public VanillaGame() { }
        public VanillaGame(string fileName) : base(fileName) { }
    }
    public class TheBurningCrusadeGame : PreMopGame
    {
        public TheBurningCrusadeGame() { }
        public TheBurningCrusadeGame(string fileName) : base(fileName) { }
    }
    public class WrathOfTheLichKingGame : PreMopGame
    {
        public WrathOfTheLichKingGame() { }
        public WrathOfTheLichKingGame(string fileName) : base(fileName) { }
    }
    public class CataclysmGame : PreMopGame
    {
        public CataclysmGame() { }
        public CataclysmGame(string fileName) : base(fileName) { }
    }
}
