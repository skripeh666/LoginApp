using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Windows.Input;
using LoginApp.Services;
using LoginApp.Models;

namespace LoginApp.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        private readonly IAuthenticationService _authenticationService;

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }

        private bool _hasError;
        public bool HasError
        {
            get { return _hasError; }
            set { SetProperty(ref _hasError, value); }
        }

        public ICommand LoginCommand { get; }

        public LoginPageViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
        {
            _navigationService = navigationService;
            _authenticationService = authenticationService;
            LoginCommand = new DelegateCommand(OnLogin);
        }

        private async void OnLogin()
        {
            var user = _authenticationService.Authenticate(Username, Password);
            if (user != null)
            {
                HasError = false;
                var navigationParams = new NavigationParameters
                {
                    { "user", user }
                };
                await _navigationService.NavigateAsync("/NavigationPage/HomePage", navigationParams);
            }
            else
            {
                ErrorMessage = "Nome de usuário ou senha inválidos.";
                HasError = true;
            }
        }
    }
}
