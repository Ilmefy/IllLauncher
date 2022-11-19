namespace IllLauncher.Model
{
    interface IGame
    {
        public string Name { get; set}
        public string GameLauncher { get; set; }
        public string CustomGameLauncher { get; set; }
        public Expansion Expansion { get; }
        
    }
}
