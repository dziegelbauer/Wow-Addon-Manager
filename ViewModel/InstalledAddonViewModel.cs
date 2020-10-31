using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using WoW_Addon_Manager.Model;

namespace WoW_Addon_Manager.ViewModel
{
    class InstalledAddonViewModel
    {
        private string addonPath = String.Empty;

        public ObservableCollection<InstalledAddon> InstalledAddons
        {
            get;
            set;
        }

        public InstalledAddonViewModel(string AddonPath)
        {
            try
            {
                if(Directory.Exists(AddonPath))
                {
                    addonPath = AddonPath;
                    LoadAddons();
                }
            }
            catch
            {

            }
        }

        public void LoadAddons()
        {
            DirectoryInfo addonFolder = new DirectoryInfo(addonPath);
            ObservableCollection<InstalledAddon> addons = new ObservableCollection<InstalledAddon>();

            foreach (DirectoryInfo di in addonFolder.GetDirectories())
            {
                InstalledAddon addon = new InstalledAddon(di.FullName);
                if(addon.LoadAddonInfo())
                {
                    addons.Add(addon);
                }
            }

            InstalledAddons = addons;
        }
    }
}
