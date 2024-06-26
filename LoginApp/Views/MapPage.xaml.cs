using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using Xamarin.Essentials.Interfaces;

namespace LoginApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
            CheckLocationPermission();
        }

        private async void CheckLocationPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

            if (status == PermissionStatus.Granted)
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    MoveMapToLocation(location.Latitude, location.Longitude);
                }
                else
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                    location = await Geolocation.GetLocationAsync(request);
                    if (location != null)
                    {
                        MoveMapToLocation(location.Latitude, location.Longitude);
                    }
                }
            }
            else
            {
                // Permissão negada, mostrar mapa centralizado em Curitiba
                MoveMapToLocation(-25.4284, -49.2733); // Coordenadas de Curitiba
            }
        }

        private void MoveMapToLocation(double latitude, double longitude)
        {
            var position = new Position(latitude, longitude);
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(1)));
        }
    }
}
