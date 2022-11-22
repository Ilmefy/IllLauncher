using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IllLauncher.Model.Extensions
{
    public static class Extensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this List<T> list)
        {
            return new ObservableCollection<T>(list);
        }
     //TODO   public static Expansion GetExpansion(GameBase game) { return Expansion.Vanilla; }
    }
}
