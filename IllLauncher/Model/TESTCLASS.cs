using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace IllLauncher.Model
{
    public static class TESTCLASS
    {
        public static List<T> GenerateServers<T>(int count, Expansion expansion)where T:ServerBase, new()
        {
            List<T> servers = new List<T>();
            for(int i=0; i<count; i++)
            {
                T server=new T();
                server.Expansion = expansion;
                server.Realmlist = $"Realmlist_{i}";
                server.Name = $"Name_{i}";
                servers.Add(server);
            }
            return servers; 
        }
        public static UserData GenerateUserData()
        {
            UserData userData = new UserData();
            userData.Servers = GenerateServers<UserServer>(10, Expansion.WrathOfTheLichKing);
            GameCreator.CreateGame("D:\\World of Warcraft - Wrath of The Lich King 3.3.5a\\Sunwell.pl-World-of-Warcraft-Win-LegionRemaster\\World of Warcraft\\Wow.exe");
            return userData;
        }
        
    }
}
