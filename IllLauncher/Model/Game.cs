using System.Diagnostics;
using System.IO;
using System.Linq;

namespace IllLauncher.Model
{

    public abstract class GameBase
    {
        public  int Id { get; set; }
        public  string Name { get; set; } = "";
        public  Expansion Expansion { get; set; }
        protected  string GameLauncherFileName { get; set; } = "";
        protected  string CustomGameLauncherFIileName { get; set; } = "";
        protected  string GameDirectory { get; set; } = "";
        protected  string AddonsDirectory { get; set; } = "";
        protected  string CacheDirectory { get; set; } = "";
        protected  string WTFDirectory { get; set; } = "";
        protected  FileVersionInfo GameLauncherFileVersionInfo { get; set; }
        protected virtual void SetRealmlist(string realmlist) { }
        protected void SetRealmlist(ServerBase server) => SetRealmlist(server.Realmlist);
        protected void SetRealmlist(Realm realm) => SetRealmlist(realm.Realmlist);
        public virtual Process StartGame()
        {

            return Process.Start(new ProcessStartInfo(GameLauncherFileName));
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
    }
    public abstract class PreMopGame : GameBase
    {
        protected string RealmlistFileName { get; set; } = "";
        public PreMopGame()
        {

        }
        public PreMopGame(string fileName) => Initialize(fileName);
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
    }
    public class TheBurningCrusadeGame:PreMopGame
    {
        public TheBurningCrusadeGame() { }
    }
    public class WrathOfTheLichKingGame:PreMopGame
    {
        public WrathOfTheLichKingGame() { }
    }
    public class CataclysmGame:PreMopGame
    {
        public CataclysmGame() { }
    }
}
