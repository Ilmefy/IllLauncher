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
        public static List<UserServer> GenerateUserServers(int count, Expansion expansion)
        {
            List<UserServer> servers = new List<UserServer>();
            string x = (expansion == Expansion.Cataclysm) ? "CATA_" : "";
            for (int i = 0; i < count; i++)
            {
                UserServer server = new UserServer($"{x}name_{i}","Set realmlist logon.TEST.PL", expansion);
                servers.Add(server);
            }
            return servers;
        }
        public static UserData GenerateUserData()
        {
            UserData userData = new UserData();
            userData.Servers = GenerateUserServers(10, Expansion.WrathOfTheLichKing);
            GameCreator.CreateGame("D:\\World of Warcraft - Wrath of The Lich King 3.3.5a\\Sunwell.pl-World-of-Warcraft-Win-LegionRemaster\\World of Warcraft\\Wow.exe");
            return userData;
        }
        
    }
}
