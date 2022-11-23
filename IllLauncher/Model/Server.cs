using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace IllLauncher.Model
{

    public abstract class ServerBase
    {
        public string Name { get; protected set; }
        public string Realmlist { get; protected set; }
        public Expansion Expansion { get; protected set; }
    }
    public class UserServer : ServerBase
    {
        public bool HasChanged;
        public void SetName(string value, bool acceptChanges=false)
        {
            if (string.Equals(Name, value))
                return;
            Name = value;
            if (!acceptChanges) HasChanged = true;
        }
        public void SetRealmlist(string value, bool acceptChanges=false) 
        {
            if (string.Equals(Realmlist, value))
                return;
            Realmlist = value;
            if (!acceptChanges) HasChanged = true;
        }


    }
    public class PublicServer : ServerBase
    {
        public List<Realm> Realms { get; }
        public Expansion Expansion { get; }
    }
    public class Realm
    {
        public string Name { get; }
        public int ServerId { get; }
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
