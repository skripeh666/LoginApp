using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LoginApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Launcher.OpenAsync(new Uri("https://www.b2ktech.com.br/"));
        }
    }
}