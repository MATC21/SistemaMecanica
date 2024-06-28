using SistemaMecanica.Entidad;
using SistemaMecanica.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SistemaMecanica.Views.PartailViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddClientePage : ContentPage
	{
        private readonly ClienteNegocio _clienteNegocio;
		public AddClientePage ()
		{
			InitializeComponent ();

            _clienteNegocio = new ClienteNegocio ();
		}

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
			 // Validar entradas
            if (string.IsNullOrWhiteSpace(cedula.Text) ||
                string.IsNullOrWhiteSpace(nombres.Text) ||
                string.IsNullOrWhiteSpace(apellidos.Text) ||
                string.IsNullOrWhiteSpace(telefono.Text) ||
                string.IsNullOrWhiteSpace(ubicacion.Text))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos", "OK");
                return;
            }

            // Crear objeto Producto
            var nuevoCliente = new Cliente
            {
                IdCliente = cedula.Text,
                Nombres = nombres.Text,
                Apellidos = apellidos.Text,
                Telefono = telefono.Text,
                Ubicacion = ubicacion.Text,
                
            };

            // Llamar a la API para crear el producto
            var clienteCreado = await _clienteNegocio.CrearCliente(nuevoCliente);

            if (clienteCreado != null)
            {
                await DisplayAlert("Éxito", "Cliente creado exitosamente", "OK");
                // Navegar a la página anterior o a la lista de productos
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "No se pudo crear el Cliente", "OK");
            }

        }
    }
}