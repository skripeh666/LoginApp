using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using LoginApp.Views;
using LoginApp.Services;
using LoginApp.ViewModels;
using Prism.Unity;

namespace LoginApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeBrandsModule())
                          .With(new Plugin.Iconize.Fonts.FontAwesomeRegularModule())
                          .With(new Plugin.Iconize.Fonts.FontAwesomeSolidModule());
            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ImagePage, ImagePageViewModel>();
            containerRegistry.RegisterForNavigation<MapPage, MapPageViewModel>(); // Adicione esta linha

            // Registro de serviços
            containerRegistry.Register<IAuthenticationService, AuthenticationService>();
        }

    }
}
