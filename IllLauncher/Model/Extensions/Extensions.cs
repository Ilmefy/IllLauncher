using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        public static bool FileExists(this string path) => File.Exists(path);
        public static bool DirectoryExists(this string directory) => Directory.Exists(directory);
        //TODO   public static Expansion GetExpansion(GameBase game) { return Expansion.Vanilla; }
    }
}
