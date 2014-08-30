using System;
using System.IO.IsolatedStorage;
using System.Reflection;
using Windows.ApplicationModel.Store;
using JustWunderMobile.Common.Interfaces;

namespace JustWunderMobile.Phone.Classes
{
    public sealed class SettingServise : ISettingService
    {
        private const string CONNECTION_TO_USE_KEY = "connection_to_use";
        private const string SYNC_ON_START_KEY = "sync_on_start";
        private const string PREVIOUS_APP_VERSION_KEY = "previous_app_version";

        private const bool RESET_SETTINGS_AFTER_UPDATE = true;

        public IsolatedStorageSettings StorageSettings
        {
            get
            {
                return IsolatedStorageSettings.ApplicationSettings;
            }
        }

        #region ISettingsService

        public bool SyncOnStart
        {
            get
            {
                var val = GetValueFromStoredge<bool>(SYNC_ON_START_KEY);

                return val;
            }
            set
            {
                SetValueToStoredge(SYNC_ON_START_KEY, value);
            }
        }
        public PrimaryConnection ConnectionToUse
        {
            get
            {
                var val = GetValueFromStoredge<PrimaryConnection>(CONNECTION_TO_USE_KEY);

                return val;
            }
            set
            {
                SetValueToStoredge(CONNECTION_TO_USE_KEY, value);
            }
        }
        
        #endregion
        public string PreviousAppVersion
        {
            get
            {
                var val = GetValueFromStoredge<string>(PREVIOUS_APP_VERSION_KEY);
                
                return string.IsNullOrEmpty(val) ? "1.0.0.0" : val;
            }
            set
            {
                SetValueToStoredge(PREVIOUS_APP_VERSION_KEY, value);
            }
        }

        #region Constructors

        public SettingServise()
        {
            
            var currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            if (PreviousAppVersion != currentVersion && RESET_SETTINGS_AFTER_UPDATE)
            {
                PreviousAppVersion = currentVersion;

                // reseting
                SyncOnStart = true;
                ConnectionToUse = PrimaryConnection.Wifi;
            }
        }

        #endregion

        #region Methods

        private T GetValueFromStoredge<T>(string key)
        {
            if (StorageSettings.Contains(key))
            {
                return (T)StorageSettings[key];
            }

            return default(T);
        }

        private void SetValueToStoredge(string key, object value)
        {
            if (StorageSettings != null)
            {
                if (StorageSettings.Contains(key))
                {
                    StorageSettings[key] = value;
                }
                else
                {
                    StorageSettings.Add(key, value);
                }
            }
        }

        #endregion
    }
}
