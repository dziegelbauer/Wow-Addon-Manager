using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace WoW_Addon_Manager.Model
{
    class InstalledAddonModel
    {
    }

    class InstalledAddon : INotifyPropertyChanged
    {
        private string addonName = String.Empty;
        private string addonVersion = String.Empty;
        private string clientVersion = String.Empty;
        private string addonPath = String.Empty;
        private string addonURL = String.Empty;

        public InstalledAddon(string path)
        {
            addonPath = path;
        }

        public string AddonName
        {
            get { return addonName;  }
            set
            {
                if(addonName != value)
                {
                    addonName = value;
                    RaisePropertyChanged("AddonName");
                }
            }
        }

        public string AddonVersion
        {
            get { return addonVersion; }
            set
            {
                if (addonVersion != value)
                {
                    addonVersion = value;
                    RaisePropertyChanged("AddonVersion");
                }
            }
        }

        public string AddonURL
        {
            get { return addonURL; }
            set
            {
                if (addonURL != value)
                {
                    addonURL = value;
                    RaisePropertyChanged("AddonURL");
                }
            }
        }

        public bool LoadAddonInfo()
        {
            DirectoryInfo addonFolder;

            try
            {
                addonFolder = new DirectoryInfo(addonPath);
            }
            catch
            {
                return false;
            }

            foreach (FileInfo file in addonFolder.GetFiles("*.toc"))
            {
                TextReader textReader = file.OpenText();

                string line;

                while ((line = textReader.ReadLine()) != null)
                {
                    if (line.StartsWith("## Interface: "))
                    {
                        clientVersion = line.Replace("## Interface: ", "");
                        continue;
                    }

                    if (line.StartsWith("## Title: "))
                    {
                        addonName = line.Replace("## Title: ", "");
                        continue;
                    }

                    if (line.StartsWith("## Version: "))
                    {
                        addonVersion = line.Replace("## Version: ", "");
                        continue;
                    }

                    if(line.StartsWith("## X-Website: "))
                    {
                        addonURL = line.Replace("## X-Website: ", "");
                        continue;
                    }
                }
            }

            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
