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
    class VehiculoNegocio
    {
        private readonly HttpClient client;
        private readonly ConsumoAPIModel api;

        public VehiculoNegocio()
        {
            
            client = new HttpClient();
            api = new ConsumoAPIModel();
        }
        public async Task<Vehiculo> ObtenerAutoxPlaca(string placa)
        {
            try
            {
                string url = await client.GetStringAsync($"{api.Obtener}/{"Vehiculoes"}/{placa}");
                Vehiculo auto = JsonConvert.DeserializeObject<Vehiculo>(url);

                return auto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mostrar los automoviles: {ex.Message}");
                return null;
            }

        }

        public async Task<Vehiculo> CrearVehiculo(Vehiculo modelo)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(modelo);

                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Enviar la solicitud POST
                var response = await client.PostAsync($"{api.Crear}/{"Vehiculoes"}", content);

                // Verificar si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta y deserializarla en un objeto Producto
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var vehiculoCreado = JsonConvert.DeserializeObject<Vehiculo>(responseContent);
                    return vehiculoCreado;
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
