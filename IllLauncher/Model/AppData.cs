using IllLauncher.Model.Extensions;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IllLauncher.Model
{
    public class AppData : IInitialize
    {
        public UserData UserData { get; set; } = new UserData();
        public PublicData PublicData { get; set; } = new PublicData();
        public bool UserDataInitialized = false;
        public IInitialize[] InitializeItems { get { return UserData.Games.ToArray<IInitialize>(); } }


        public AppData(bool initializeAtCreate = true)
        {
            if (initializeAtCreate)
                Task.Factory.StartNew(()=> Initialize());
        }
        public async Task Initialize() => Task.Factory.StartNew(() => GetUserData());
        private async Task GetUserData()
        {

            if (ReadonlyData.UserDataFileName.FileExists())
            {
                try
                {
                    JsonHelper jsonHelper = new JsonHelper();
                    //Dont assign it to UserData, first it needs to be Initialized
                    UserData = await jsonHelper.DeserializeAsync<UserData>(ReadonlyData.UserDataFileName);
                    InitializeObjects();
                  await  Task.Factory.StartNew(()=>InitializeObjects());
                    UserDataInitialized = true;
                }
                catch (Exception)
                {

                }
            }

        }
        private async Task InitializeObjects()
        {
            foreach (var item in InitializeItems)
            {
                item.Initialize();
            }
        }

    }
    public class UserData
    {
        [JsonIgnore]
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
