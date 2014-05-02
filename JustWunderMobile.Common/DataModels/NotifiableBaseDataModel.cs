using JustWunderMobile.Common.Annotations;
using System.ComponentModel;

namespace JustWunderMobile.Common.DataModels
{
    /// <summary>
    /// Base class for datamodels which need to raise property changed event after update any property
    /// Note: Temporary decision //TODO: this is a viewmodel responsibility, not data, figure this out!
    /// </summary>
    public abstract class NotifiableBaseDataModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
