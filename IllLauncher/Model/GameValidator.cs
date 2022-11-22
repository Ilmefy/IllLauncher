namespace IllLauncher.Model
{
    public abstract class GameValidator
    {
        public static void Validate(string fileName) 
        {
            
            
        }
        protected  readonly string[] _requiredFiles;
        protected  readonly string[] _requiredDirectories;
        protected virtual bool CheckRequiredFiles(string fileName)
        {
            return true;
        }
        protected virtual bool CheckRequiredDirectories(string fileName)
        {
            return true;
        }
    }
    
}
