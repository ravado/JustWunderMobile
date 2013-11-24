
using System.Collections.Generic;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Testing;

namespace JustWunderMobile.Phone.Test
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.Content = UnitTestSystem.CreateTestPage();
        }
    }
}