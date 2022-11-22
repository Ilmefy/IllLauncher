using IllLauncher.Model;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IllLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PreMopGame preMopGame = new PreMopGame(@"D:\World of Warcraft - Wrath of The Lich King 3.3.5a\Sunwell.pl-World-of-Warcraft-Win-LegionRemaster\World of Warcraft\Wow.exe");
            

        }
    }
}
