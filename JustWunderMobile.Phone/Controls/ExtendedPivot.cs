using Microsoft.Phone.Controls;
using System;
using System.Windows;

namespace JustWunderMobile.Phone.Controls
{
    public class ExtendedPivot : Pivot
    {
        public ExtendedPivot() : base()
        {
        }

        public Boolean BindableIsLocked
        {
            get { return (Boolean) this.GetValue(BindableIsLockedProperty); }
            set { this.SetValue(BindableIsLockedProperty, value); }
        }

        public static readonly DependencyProperty BindableIsLockedProperty = DependencyProperty.Register(
            "BindableIsLocked", typeof (Boolean), typeof (ExtendedPivot),
            new PropertyMetadata(false, BindableIsLockedChanged));

        private static void BindableIsLockedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            var pivot = d as ExtendedPivot;
            if (pivot != null)
            {
                pivot.IsLocked = (bool) e.NewValue;
            }
        }
    }
}
