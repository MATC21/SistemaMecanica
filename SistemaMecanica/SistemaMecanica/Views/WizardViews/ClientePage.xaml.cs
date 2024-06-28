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
	public partial class ClientePage : ContentPage
	{
        private ClienteNegocio _clienteNegocio;
        public ClientePage ()
		{
			InitializeComponent ();
            _clienteNegocio = new ClienteNegocio ();

        }

        public async void btnSiguiente_Clicked(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                Nombres = nombres.Text,
                Apellidos = apellidos.Text,
                IdCliente = cedula.Text,
                Telefono = telefono.Text,
                Ubicacion = ubicacion.Text
            };

            await Navigation.PushAsync(new AutomovilPage(cliente));
        }

        private async void cargarCliente_Clicked(object sender, EventArgs e)
        {
            string ci = cedula.Text;
            if (!string.IsNullOrWhiteSpace(ci))
            {
                Cliente cliente = await _clienteNegocio.ObtenerClientexCedula(ci);
                if (cliente != null)
                {
                    nombres.Text = cliente.Nombres;
                    apellidos.Text = cliente.Apellidos;
                    telefono.Text = cliente.Telefono;
                    ubicacion.Text = cliente.Ubicacion;
                }
                else
                {
                    await DisplayAlert("Error", "No se encontró el cliente", "Aceptar");
                    // Limpia los campos si no se encuentra el cliente
                    nombres.Text = string.Empty;
                    apellidos.Text = string.Empty;
                    telefono.Text = string.Empty;
                    ubicacion.Text = string.Empty;
                }
            }
            else
            {
                await DisplayAlert("Error", "Ingrese la cédula del cliente", "Aceptar");
            }
        }
    }
}