using SistemaMecanica.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaMecanica.Views.WizardViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetallePage : ContentPage
    {
        private DatosDetalle _datosDetalle;
        public DetallePage(DatosDetalle datosDetalle)
        {
            InitializeComponent();

            _datosDetalle = datosDetalle;

            // Cargar datos del cliente
            nombreEntry.Text = _datosDetalle.Cliente.Nombres;
            apellidoEntry.Text = _datosDetalle.Cliente.Apellidos;
            cedulaEntry.Text = _datosDetalle.Cliente.IdCliente;

            // Cargar datos del vehículo
            placaEntry.Text = _datosDetalle.Vehiculo.Placa;

            // Cargar lista de tareas
            tareasListView.ItemsSource = _datosDetalle.Tareas;
        }

        private async void btnTerminar_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Confirmación", "¿Desea Finalizar?", "Continuar", "Cancelar");
            if (answer)
            {
                await Navigation.PushAsync(new DetailPage());
            }
        }
    }
}