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
    class MarcaNegocio
    {
        private readonly HttpClient client;
        private readonly ConsumoAPIModel api;

        public MarcaNegocio()
        {
            client = new HttpClient();
            api = new ConsumoAPIModel();
        }
        public async Task<List<MarcaAutomovil>> ObtenerMarcas()
        {
            try
            {
                string url = await client.GetStringAsync($"{api.Listar}/{"MarcasVehiculoes"}");
                List<MarcaAutomovil> listaMarcas = JsonConvert.DeserializeObject<List<MarcaAutomovil>>(url);
                return listaMarcas;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mostrar los productos: {ex.Message}");
                return null;
            }

        }
    }
}
