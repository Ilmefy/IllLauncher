using IllLauncher.Model;

using Microsoft.Toolkit.Mvvm.ComponentModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IllLauncher.ViewModel
{
    public partial class ShellViewModel:ObservableObject
    {
        public AppData AppData = new AppData();
        public ShellViewModel()
        {
            Initializer.Initialize(ref AppData);
        }
    }
}
