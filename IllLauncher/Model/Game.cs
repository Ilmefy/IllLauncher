using Newtonsoft.Json;

using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace IllLauncher.Model
{

    public abstract class GameBase
    {
        public int Id { get; protected set; }
        public void SetId(int id, bool acceptChange=false)
        {
            if(Id == id) return;
            Id = id;
            if (!acceptChange) HasChanged = true;
        }
        public string Name { get; protected set; } = "";
        public void SetName(string name, bool acceptChange = false)
        {
            if (Name == name) return;
            Name = name;
            if(!acceptChange) HasChanged = true;
        }
        public void SetGameLauncherFileName(string filename, bool acceptChange = false)
        {
            if(GameLauncherFileName == filename) return;
            GameLauncherFileName = filename;
            if (!acceptChange) HasChanged = true;
        }
        [JsonIgnore]
        public Expansion Expansion { get; protected set; }
        [JsonIgnore]
        public bool HasChanged { get; protected set; }
        public string GameLauncherFileName { get; set; } = "";
        protected string CustomGameLauncherFileName { get;  set; } = "";
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
            GameLauncherFileName = fileName;
            GameLauncherFileVersionInfo = FileVersionInfo.GetVersionInfo(GameLauncherFileName);
            Expansion = (Expansion)int.Parse(GameLauncherFileVersionInfo.FileVersion[0].ToString());
            GameDirectory = Path.GetDirectoryName(GameLauncherFileName);
            AddonsDirectory = Directory.GetDirectories(GameDirectory, "Addons", SearchOption.AllDirectories).First();
            CacheDirectory = Directory.GetDirectories(GameDirectory, "Cache", SearchOption.AllDirectories).First(); ;
            WTFDirectory = Directory.GetDirectories(GameDirectory, "WTF", SearchOption.AllDirectories).First(); ;

        }
        public GameBase()
        {
        }
        public GameBase(string fileName)
        {
            Initialize(fileName);
            HasChanged = true;
        }
    }
    public abstract class PreMopGame : GameBase
    {
        
        protected string RealmlistFileName { get; set; } = "";
        public PreMopGame() { }
        public PreMopGame(string fileName) :base(fileName) { }
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
    public class TheBurningCrusadeGame:PreMopGame
    {
        public TheBurningCrusadeGame() { }
        public TheBurningCrusadeGame(string fileName) : base(fileName) { }
    }
    public class WrathOfTheLichKingGame:PreMopGame
    {
        public WrathOfTheLichKingGame() { }
        public WrathOfTheLichKingGame(string fileName) : base(fileName) { }
    }
    public class CataclysmGame:PreMopGame
    {
        public CataclysmGame() { }
        public CataclysmGame(string fileName) : base(fileName) { }
    }
}
