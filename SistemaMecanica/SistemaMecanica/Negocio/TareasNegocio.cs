using Newtonsoft.Json;
using SistemaMecanica.Entidad;
using SistemaMecanica.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMecanica.Negocio
{
    class TareasNegocio
    {
        private readonly HttpClient client;
        private readonly ConsumoAPIModel api;

        public TareasNegocio()
        {
            client = new HttpClient();
            api = new ConsumoAPIModel();
        }
        public async Task<List<Tarea>> ObtenerTareas()
        {
            try
            {
                string url = await client.GetStringAsync($"{api.Listar}/{"Tareas"}");
                List<Tarea> listaTareas = JsonConvert.DeserializeObject<List<Tarea>>(url);
                return listaTareas;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mostrar los productos: {ex.Message}");
                return null;
            }

        }

        public async Task<Tarea> CrearTarea(Tarea modelo)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(modelo);

                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Enviar la solicitud POST
                var response = await client.PostAsync($"{api.Crear}/{"Tareas"}", content);

                // Verificar si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta y deserializarla en un objeto Producto
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var TareaCreada = JsonConvert.DeserializeObject<Tarea>(responseContent);
                    return TareaCreada;
                }
                else
                {
                    // Manejar el caso en que la solicitud no fue exitosa
                    throw new Exception($"Error al crear el producto: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el producto: {ex.Message}");
                return null;
            }

        }
    }
}
