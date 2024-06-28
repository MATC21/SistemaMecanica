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
    public partial class AddVehiculo : ContentPage
    {
        private readonly MarcaNegocio _marcaNegocio;
        private readonly ModeloNegocio _modeloNegocio;
        private readonly VehiculoNegocio _vehiculoNegocio;
        private readonly ClienteNegocio _clienteNegocio;

        private List<MarcaAutomovil> marcasDisponibles;
        private List<ModeloAutomovil> modeloDisponibles;
        private List<Cliente> clientesDisponibles;

        private int idMarca;
        private int idModelo;
        private string idCliente;
        public AddVehiculo()
        {
            InitializeComponent();

            
            _marcaNegocio = new MarcaNegocio();
            _modeloNegocio = new ModeloNegocio();
            _vehiculoNegocio = new VehiculoNegocio();
            _clienteNegocio = new ClienteNegocio();

            CargarMarcasEnPicker();
            CargarClientesEnPicker();

            marcasDisponibles = new List<MarcaAutomovil>();
        }

        private async void CargarMarcasEnPicker()
        {
            var marcas = await _marcaNegocio.ObtenerMarcas();
            if (marcas != null)
            {
                marcasDisponibles = marcas;
                foreach (var marcaV in marcas)
                {
                    marcaPicker.Items.Add(marcaV.Marca);
                }
            }
        }

        private async void CargarClientesEnPicker()
        {
            var clientes = await _clienteNegocio.ObtenerTodosLosClientes();
            if (clientes != null)
            {
                clientesDisponibles = clientes;
                foreach (var cliente in clientes)
                {
                    clientePicker.Items.Add(cliente.IdCliente);
                }
            }
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            // Validar entradas
            if (string.IsNullOrWhiteSpace(placaEntry.Text) ||
                string.IsNullOrWhiteSpace(kilometrajeEntry.Text) ||
                string.IsNullOrWhiteSpace(anioEntry.Text))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos", "OK");
                return;
            }

            // Crear objeto Producto
            var nuevoVehiculo = new Vehiculo
            {
                Placa = placaEntry.Text,
                Kilometraje = Convert.ToInt16(kilometrajeEntry.Text),
                IdMarca = idMarca,
                IdModelo = idModelo,
                Anio = Convert.ToInt16(anioEntry.Text),
                IdCliente = idCliente

            };

            // Llamar a la API para crear el producto
            var vehiculoCreado = await _vehiculoNegocio.CrearVehiculo(nuevoVehiculo);

            if (vehiculoCreado != null)
            {
                await DisplayAlert("Éxito", "Vehículo creado exitosamente", "OK");
                // Navegar a la página anterior o a la lista de productos
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "No se pudo crear el Vehiculo", "OK");
            }
        }

        private async void marcaPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice seleccionado del Picker
            int selectedIndex = marcaPicker.SelectedIndex;

            if (selectedIndex != -1)
            {
                // Obtener el objeto MarcaAutomovil seleccionado
                MarcaAutomovil marcaSeleccionada = marcasDisponibles[selectedIndex];

                // Asignar el id de la marca seleccionada a la variable idMarca
                idMarca = marcaSeleccionada.IdMarca; // Ajusta según la propiedad que corresponda al id en MarcaAutomovil

                // Limpiar items actuales del modeloPicker
                modeloPicker.Items.Clear();

                // Obtener y cargar los modelos de la marca seleccionada
                var modelos = await _modeloNegocio.ObtenerModelos(idMarca);
                if (modelos != null)
                {
                    modeloDisponibles = modelos;
                    foreach (var modelo in modelos)
                    {
                        modeloPicker.Items.Add(modelo.Modelo);
                    }
                }
            }
        }

        private void modeloPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice seleccionado del Picker
            int selectedIndex = modeloPicker.SelectedIndex;

            if (selectedIndex != -1)
            {
                // Obtener el objeto MarcaAutomovil seleccionado
                ModeloAutomovil modeloSeleccionada = modeloDisponibles[selectedIndex];

                // Asignar el id de la marca seleccionada a la variable idMarca
                idModelo = modeloSeleccionada.IdModelo; // Ajusta según la propiedad que corresponda al id en MarcaAutomovil

            }
        }

        private void clientePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice seleccionado del Picker
            int selectedIndex = clientePicker.SelectedIndex;

            if (selectedIndex != -1)
            {
                // Obtener el objeto Cliente seleccionado
                Cliente clienteSeleccionado = clientesDisponibles[selectedIndex];

                // Asignar el id del cliente seleccionado a la variable idCliente
                idCliente = clienteSeleccionado.IdCliente; // Ajusta según la propiedad que corresponda al id en Cliente (debe ser string)

            }
        }
    }
}