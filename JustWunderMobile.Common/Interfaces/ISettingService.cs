using System.ComponentModel;

namespace JustWunderMobile.Common.Interfaces
{
    public interface ISettingService
    {
        PrimaryConnection ConnectionToUse { get; set; }
        bool SyncOnStart { get; set; }
    }

    [DefaultValue(None)]
    public enum PrimaryConnection
    {
        None,
        Any,
        Wifi,
        Mobile
    }
}
