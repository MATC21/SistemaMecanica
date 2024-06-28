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
    public partial class AddTarea : ContentPage
    {
        private readonly TareasNegocio _tareaNegocio;
        public AddTarea()
        {
            InitializeComponent();
            _tareaNegocio = new TareasNegocio();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            // Validar entradas
            if (string.IsNullOrWhiteSpace(descripcion.Text) ||
                string.IsNullOrWhiteSpace(kilometrajeProximoCambio.Text))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos", "OK");
                return;
            }

            // Crear objeto Producto
            var nuevaTarea = new Tarea
            {
                Descripcion = descripcion.Text,
                KilometrajeProximoCambio = (int?)Convert.ToInt64(kilometrajeProximoCambio.Text)

            };

            // Llamar a la API para crear el producto
            var TareaCreada = await _tareaNegocio.CrearTarea(nuevaTarea);

            if (nuevaTarea != null)
            {
                await DisplayAlert("Éxito", "Tarea creadoa exitosamente", "OK");
                // Navegar a la página anterior o a la lista de productos
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "No se pudo crear la Tarea", "OK");
            }
        }
    }
}