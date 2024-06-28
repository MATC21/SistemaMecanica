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
    public partial class TareasPage : ContentPage
    {
        private readonly TareasNegocio _tareasNegocio;
        private List<Tarea> tareasSeleccionadas;
        private List<Tarea> tareasDisponibles;

        private Vehiculo _vehiculo;

        private Cliente _cliente;
        public TareasPage(Cliente cliente, Vehiculo vehiculo)
        {
            InitializeComponent();
            _tareasNegocio = new TareasNegocio();
            tareasSeleccionadas = new List<Tarea>();
            tareasDisponibles = new List<Tarea>();
            CargarTareasEnPicker();

            _cliente = cliente;
            _vehiculo = vehiculo;
        }

        private async void btnTerminar_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Confirmación", "¿Desea continuar?", "Continuar", "Cancelar");
            if (answer)
            {
                var datosDetalle = new DatosDetalle
                {
                    Cliente = _cliente,
                    Vehiculo = _vehiculo,
                    Tareas = tareasSeleccionadas
                };
                // Navegar a otra vista
                await Navigation.PushAsync(new DetallePage(datosDetalle)); // Reemplaza 'OtraVistaPage' con tu página destino
            }
        }

        private async void CargarTareasEnPicker()
        {
            var tareas = await _tareasNegocio.ObtenerTareas();
            if (tareas != null)
            {
                tareasDisponibles = tareas;
                foreach (var tarea in tareas)
                {
                    marcaPicker.Items.Add(tarea.Descripcion);
                }
            }
        }

        private void marcaPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (marcaPicker.SelectedIndex != -1)
            {
                var selectedTarea = tareasDisponibles[marcaPicker.SelectedIndex];
                tareasSeleccionadas.Add(selectedTarea);
                ActualizarTareasListView();
                marcaPicker.SelectedIndex = -1; // Limpiar el Picker
            }
        }

        private void EliminarTarea_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var tarea = button.BindingContext as Tarea;
            if (tarea != null)
            {
                tareasSeleccionadas.Remove(tarea);
                ActualizarTareasListView();
            }
        }

        private void ActualizarTareasListView()
        {
            tareasListView.ItemsSource = null;
            tareasListView.ItemsSource = tareasSeleccionadas;
        }
    }
}
