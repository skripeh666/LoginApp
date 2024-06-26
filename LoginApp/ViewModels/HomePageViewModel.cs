using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Windows.Input;
using LoginApp.Models;
using Xamarin.Forms;

namespace LoginApp.ViewModels
{
    public class HomePageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private Usuario _currentUser;

        public ICommand NavigateToImagePageCommand { get; }
        public ICommand NavigateToSystemPageCommand { get; }
        public ICommand NavigateToMapPageCommand { get; }
        public ICommand LogoutCommand { get; }

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToImagePageCommand = new DelegateCommand(OnNavigateToImagePage);
            NavigateToSystemPageCommand = new DelegateCommand(OnNavigateToSystemPage);
            NavigateToMapPageCommand = new DelegateCommand(OnNavigateToMapPage);
            LogoutCommand = new DelegateCommand(OnLogout);
        }

        private async void OnNavigateToImagePage()
        {
            await _navigationService.NavigateAsync("ImagePage");
        }

        private async void OnNavigateToSystemPage()
        {
            if (_currentUser.Tipo == TipoUsuario.Admin)
            {
                await _navigationService.NavigateAsync("MainPage");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Acesso Negado", "Você não tem permissão para acessar esta página.", "OK");
            }
        }

        private async void OnNavigateToMapPage()
        {
            if (_currentUser.Tipo == TipoUsuario.Intermediario || _currentUser.Tipo == TipoUsuario.Admin)
            {
                await _navigationService.NavigateAsync("MapPage");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Acesso Negado", "Você não tem permissão para acessar esta página.", "OK");
            }
        }

        private async void OnLogout()
        {
            await _navigationService.NavigateAsync("/LoginPage");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("user"))
            {
                _currentUser = parameters.GetValue<Usuario>("user");
            }
        }
    }
}
