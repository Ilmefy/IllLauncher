using System;
using System.Collections.Generic;

namespace IllLauncher.Model
{
    
    public abstract class ServerBase
    {
        public string Name { get; set; }
        public string Realmlist { get; set; }
        public Expansion Expansion { get; set; }
    }
    public class UserServer : ServerBase
    {
        
        
    }
    public class PublicServer : ServerBase
    {
        public List<Realm> Realms { get; }
        public Expansion Expansion { get;  }
    }
    public class Realm
    {
        public string Name {get;}
        public int ServerId { get;}
        public string Description { get; }
        public string? Realmlist { get; }
        public List<Social> Socials { get; set; }
    }
    public class Social
    {
        public string Name { get; } = "";

        public string Description { get; } = "";

        public string Url { get; } = "";

        public string Icon { get; } = "";
    }
}
