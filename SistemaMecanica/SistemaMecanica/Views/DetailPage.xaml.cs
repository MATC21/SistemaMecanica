using SistemaMecanica.Views.WizardViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaMecanica.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage()
        {
            InitializeComponent();
        }

        private async void btnComenzar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClientePage());
        }
    }
}