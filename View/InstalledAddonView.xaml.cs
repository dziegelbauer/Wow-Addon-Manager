using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WoW_Addon_Manager.ViewModel;

namespace WoW_Addon_Manager.View
{
    /// <summary>
    /// Interaction logic for InstalledAddonView.xaml
    /// </summary>
    public partial class InstalledAddonView : UserControl
    {
        public InstalledAddonView()
        {
            InitializeComponent();
            this.DataContext = new InstalledAddonViewModel(@"C:\Users\dzieg\source\repos\Wow-Addon-Manager\TestWow\_retail_\Interface\Addons");
        }
    }
}
