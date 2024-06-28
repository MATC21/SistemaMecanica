using Firebase.Auth;
using Newtonsoft.Json;
using SistemaMecanica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaMecanica.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioPage : ContentPage
    {
        FireBaseModel model = new FireBaseModel();
        public InicioPage()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            string emaili = email.Text.Trim();
            string passwordi = password.Text.Trim();

            if (!IsValidEmail(emaili))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Por favor, ingresa un correo electrónico válido.", "Ok");
                return;
            }

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(model.ClaveAPIweb));

            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(emaili, passwordi);
                var content = await auth.GetFreshAuthAsync();
                var serializedContent = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedContent);

                MainPage mainPage = new MainPage();
                App.Current.MainPage = mainPage;
                NavigationPage.SetHasNavigationBar(mainPage, false);


            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Usuario No Valido", "Ok");
            }

        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}