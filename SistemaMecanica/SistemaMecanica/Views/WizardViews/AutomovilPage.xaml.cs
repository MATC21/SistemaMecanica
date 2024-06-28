using SistemaMecanica.Entidad;
using SistemaMecanica.Negocio;
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
    public partial class AutomovilPage : ContentPage
    {
        private VehiculoNegocio _vehiculoNegocio;

        private Cliente _cliente;
        public AutomovilPage(Cliente cliente)
        {
            InitializeComponent();
            _vehiculoNegocio = new VehiculoNegocio();
            _cliente = cliente;
        }

        private async void btnSiguiente_Clicked(object sender, EventArgs e)
        {
            Vehiculo vehiculo = new Vehiculo
            {
                Placa = placaEntry.Text,
                // Añadir más propiedades según sea necesario
            };
            await Navigation.PushAsync(new TareasPage(_cliente,vehiculo));
        }

        private async void cargarCliente_Clicked(object sender, EventArgs e)
        {
            string placa = placaEntry.Text;
            if (!string.IsNullOrWhiteSpace(placa))
            {
                Vehiculo vehiculo = await _vehiculoNegocio.ObtenerAutoxPlaca(placa);
                if (vehiculo != null)
                {
                    marca.Text = Convert.ToString(vehiculo.IdMarca);
                    modelo.Text = Convert.ToString(vehiculo.IdModelo);
                    año.Text = Convert.ToString(vehiculo.Anio);
                }
                else
                {
                    await DisplayAlert("Error", "No se encontró el automovil", "Aceptar");
                    // Limpia los campos si no se encuentra el cliente
                    marca.Text = string.Empty;
                    modelo.Text = string.Empty;
                    año.Text = string.Empty;
                }
            }
            else
            {
                await DisplayAlert("Error", "Ingrese la placa del automovil", "Aceptar");
            }
        }
    }
}