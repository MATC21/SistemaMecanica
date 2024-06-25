using SistemaMecanica.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaMecanica
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDet { get; set; }
        public App()
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(Preferences.Get("MyFirebaseRefreshToken", "")))
            {
                MainPage = new MainPage(); // Aquí se establece la MainPage como la página principal
            }
            else
            {
                MainPage = new NavigationPage(new InicioPage());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
