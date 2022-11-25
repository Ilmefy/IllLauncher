using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IllLauncher.Model
{
    public class AppData
    {
        public UserData UserData { get; set; }
        public PublicData PublicData { get; set; }
    }
    public class UserData
    {
        public bool HasChanged
        {
            get
            {
                if (Games.Any(c => c.HasChanged) || Servers.Any(c => c.HasChanged))
                    return true;
                return false;
            }
        }
        public List<GameBase> Games { get; set; } = new List<GameBase>();
        public List<UserServer> Servers { get; set; } = new List<UserServer>();

    }
    public class PublicData
    {
        public List<PublicServer> Servers { get; set; } = new List<PublicServer>();
    }
}
