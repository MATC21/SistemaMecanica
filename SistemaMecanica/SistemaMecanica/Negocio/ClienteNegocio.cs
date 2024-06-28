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
    class ClienteNegocio
    {
        private readonly HttpClient client;
        private readonly ConsumoAPIModel api;

        public ClienteNegocio()
        {
            client = new HttpClient();
            api = new ConsumoAPIModel();
        }

        public async Task<List<Cliente>> ObtenerTodosLosClientes()
        {
            try
            {
                string url = await client.GetStringAsync($"{api.Listar}/{"Clientes"}");
                List<Cliente> listaProductos = JsonConvert.DeserializeObject<List<Cliente>>(url);
                return listaProductos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mostrar los productos: {ex.Message}");
                return null;
            }

        }

        public async Task<Cliente> ObtenerClientexCedula(string ci)
        {
            try
            {
                string url = await client.GetStringAsync($"{api.Obtener}/{"Clientes"}/{ci}");
                Cliente cliente = JsonConvert.DeserializeObject<Cliente>(url);

                return cliente;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mostrar los clientes: {ex.Message}");
                return null;
            }

        }

        public async Task<Cliente> CrearCliente(Cliente modelo)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(modelo);

                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Enviar la solicitud POST
                var response = await client.PostAsync($"{api.Crear}/{"Clientes"}", content);

                // Verificar si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Leer la respuesta y deserializarla en un objeto Producto
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var clienteCreado = JsonConvert.DeserializeObject<Cliente>(responseContent);
                    return clienteCreado;
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
