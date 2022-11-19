using System.Collections.Generic;

namespace IllLauncher.Model
{
    #region Classes
    public class UserServer : IServer
    {
        #region InterfaceImplementation
        public string Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Realmlist { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public Expansion Expansion { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        #endregion
    }
    public class PublicServer : IPublicServer
    {
        #region InterfaceImplementation
        public string Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Realmlist { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public Expansion Expansion { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        #endregion
        public List<IRealm> Realms { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
    public class Realm : IRealm
    {
        public string Name => throw new System.NotImplementedException();

        public string Description => throw new System.NotImplementedException();
    }
    public class Socials : ISocials
    {
        List<ISocial> ISocials.Socials { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
    public class Social : ISocial
    {
        public string Name => throw new System.NotImplementedException();

        public string Description => throw new System.NotImplementedException();

        public string Url => throw new System.NotImplementedException();

        public string Icon => throw new System.NotImplementedException();
    }


    #endregion
    #region Interfaces
    public interface IServer
    {
        public string Name { get; set; }
        public string Realmlist { get; set; }
        public Expansion Expansion { get; set; }
    }
    public interface IPublicServer:IServer
    {
        public List<IRealm> Realms { get; set; }

    }
    public interface IRealm
    {
        public string Name { get;}
        public string Description { get;}

    }
    public interface ISocials
    {
        List<ISocial> Socials { get; set; }
    }
    public interface ISocial
    {
        public string Name { get;}
        public string Description { get;}
        public string Url { get; }
        public string Icon { get; }
    }
    #endregion
}
