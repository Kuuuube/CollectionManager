﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App.Properties
{


    internal sealed partial class Settings
    {
        public void Save() { }
        public void Reset() { }
        private static Settings instance = new Settings();
        public static Settings Default
        {
            get
            {
                return instance;
            }
        }

        public bool DontAskAboutOsuDirectory
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        public bool Audio_autoPlay
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        public bool Audio_playerMode
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        public float Audio_volume
        {
            get
            {
                return 0.3f;
            }
            set
            {
            }
        }

        public string Osustats_apiKey
        {
            get
            {
                return string.Empty;
            }
            set
            {
            }
        }

        public string OsuDirectory
        {
            get
            {
                return string.Empty;
            }
            set
            {
            }
        }

        public string DownloadManager_DownloaderSettings
        {
            get
            {
                return "{}";
            }
            set
            {
            }
        }
    }
}
