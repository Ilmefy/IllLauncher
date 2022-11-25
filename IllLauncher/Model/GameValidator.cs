using System;
using System.IO;
using System.Linq;

namespace IllLauncher.Model
{
    public class RequiredFilesAreMissingException:Exception
    {
        public RequiredFilesAreMissingException():base() { }
        public RequiredFilesAreMissingException(string message) : base(message) { }
    }
    public class RequiredDirectoriesAreMissingException:Exception
    {
        public RequiredDirectoriesAreMissingException():base() { }
        public RequiredDirectoriesAreMissingException(string message):base(message) { }
    }
    public abstract class GameValidatorBase
    {
        protected string[] _requiredFiles { get; set; }
        protected string[] _requiredDirectories { get; set; }
        protected string _fileName = "";
        protected string _fileDirectory { get { return Path.GetDirectoryName(_fileName); } }
        protected virtual bool DirectoryContainsRequiredFiles()
        {
            string[] files = System.IO.Directory.GetFiles(_fileDirectory);
            for (int i = 0; i < _requiredFiles.Count(); i++)
            {
                if (!files.Any(c => Path.GetFileName(c).ToLower() == _requiredFiles[i].ToLower()))
                    throw new RequiredFilesAreMissingException(_requiredFiles[i]);
            }
            return true;
        }
        protected virtual bool DirectoryContainsRequiredDictionaries()
        {
            string[] directories = System.IO.Directory.GetDirectories(_fileDirectory);
            string folderNmae = Path.GetFileName(directories[0]);
            for (int i = 0; i < _requiredDirectories.Count(); i++)
            {
                if (!directories.Any(c => Path.GetFileName(c).ToLower() == _requiredDirectories[i].ToLower()))
                    throw new RequiredDirectoriesAreMissingException(_requiredDirectories[i]);
            }
            return true;
        }
        protected virtual bool IsFileCreatedByBlizzard()
        {
            return true;
        }
        protected virtual bool IsFileExecutableFile()
        {
            return true;
        }
        public bool Validate()
        {
            if (DirectoryContainsRequiredDictionaries() && DirectoryContainsRequiredFiles())
                return true;
            return false;
        }
        public GameValidatorBase(string fileName)
        {
            _fileName = fileName;
        }
    }
    public class VanillaGameValidator : GameValidatorBase
    {
        public VanillaGameValidator(string fileName) : base(fileName)
        {
            _requiredDirectories = new string[] { "Cache", "Data" };
            _requiredFiles = new string[] { "BackgroundDownloader.exe" };
        }
        public bool Validate() => base.Validate();
    }
    public class WrathOfTheLichKingValidator : GameValidatorBase
    {
        public WrathOfTheLichKingValidator(string fileName) : base(fileName)
        {
            _requiredDirectories = new string[] { "Cache", "Data" };
            _requiredFiles = new string[] { "BackgroundDownloader.exe" };
        }
        public bool Validate() => base.Validate();
    }
    public static class GameCreator
    {
        public static bool Validate(string fileName)
        {
            GameValidatorBase? gameValidatorBase = null;
            Expansion expansion = GameBase.GetExpansion(fileName);
            switch (expansion)
            {
                case Expansion.All:
                case Expansion.Vanilla:
                    gameValidatorBase = new VanillaGameValidator(fileName);
                    break;
                case Expansion.TheBurningCrusade:
                    break;
                case Expansion.WrathOfTheLichKing:
                    gameValidatorBase=new WrathOfTheLichKingValidator(fileName); break;
                case Expansion.Cataclysm:
                    break;
                case Expansion.MistsOfPandaria:
                    break;
                case Expansion.WarlodsOfDraenor:
                    break;
                case Expansion.Legion:
                    break;
                case Expansion.BattleForAzeroth:
                    break;
                case Expansion.Shadowlands:
                    break;
                case Expansion.Dragonflight:
                    break;
            }
            if (gameValidatorBase != null)
                return gameValidatorBase.Validate();
            return false;
        }
        public static GameBase? CreateGame(string fileName, bool validate = true)
        {
            if (validate)
                if (!Validate(fileName))
                {
                    return null;
                }
            return CreateGame(GameBase.GetExpansion(fileName), fileName);
        }
        private static GameBase? CreateGame(Expansion expansion, string fileName)
        {
            switch (expansion)
            {
                case Expansion.All:
             
                //case Expansion.Vanilla:
                //    return new VanillaGame(fileName);
                //case Expansion.TheBurningCrusade:
                //    return new TheBurningCrusadeGame(fileName);
                case Expansion.WrathOfTheLichKing:
                    return new WrathOfTheLichKingGame(fileName);
                case Expansion.Cataclysm:
                    //return new CataclysmGame(fileName);
                case Expansion.MistsOfPandaria:
                    break;
                case Expansion.WarlodsOfDraenor:
                    break;
                case Expansion.Legion:
                    break;
                case Expansion.BattleForAzeroth:
                    break;
                case Expansion.Shadowlands:
                    break;
                case Expansion.Dragonflight:
                    break;
            }
            return null;

        }
    }
}