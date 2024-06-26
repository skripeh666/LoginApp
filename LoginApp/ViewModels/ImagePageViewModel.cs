using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;
using Xamarin.Essentials;

namespace LoginApp.ViewModels
{
    public class ImagePageViewModel : BindableBase
    {
        public ICommand OpenWebCommand { get; }

        public ImagePageViewModel()
        {
            OpenWebCommand = new DelegateCommand(OpenWeb);
        }

        private void OpenWeb()
        {
            Browser.OpenAsync(new System.Uri("https://www.eaware.com.br/"), BrowserLaunchMode.SystemPreferred);
        }
    }
}