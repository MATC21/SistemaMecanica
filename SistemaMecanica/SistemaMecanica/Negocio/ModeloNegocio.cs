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
    class ModeloNegocio
    {
        private readonly HttpClient client;
        private readonly ConsumoAPIModel api;

        public ModeloNegocio()
        {
            client = new HttpClient();
            api = new ConsumoAPIModel();
        }

        public async Task<List<ModeloAutomovil>> ObtenerModelos(int idMarca)
        {
            try
            {
                string url = await client.GetStringAsync($"{api.Listar}/{"ModeloVehiculoes"}/{idMarca}");
                List<ModeloAutomovil> listaModelos = JsonConvert.DeserializeObject<List<ModeloAutomovil>>(url);
                return listaModelos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mostrar los productos: {ex.Message}");
                return null;
            }


        }
    }
}
