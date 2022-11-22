using System;
using System.Collections.Generic;

namespace IllLauncher.Model
{
    #region Classes
    public class UserServer : ServerBase
    {

        
    }
    public class PublicServer : ServerBase
    {
        public List<Realm> Realms { get; }
        public Expansion Expansion { get;  }
        #endregion

    }
    public class Realm
    {
        public string Name {get;}
        public int ServerId { get;}
        public string Description { get; }
        public string? Realmlist { get; }
    }
    public class SocialBase
    {
        public string Name { get; }

        public string Description { get; }

        public string Url { get; }

        public string Icon { get; }
    }

    public abstract class ServerBase
    {
        public string Name { get; set; }
        public string Realmlist { get; set; }
        public Expansion Expansion { get; set; }
    }
    public  class Social
    {
        public string Name { get;}
        public string Description { get;}
        public string Url { get; }
        public string Icon { get; }
    }
}
