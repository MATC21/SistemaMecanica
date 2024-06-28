using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaMecanica.Entidad
{
    public class Vehiculo
    {
        public string Placa { get; set; }

        public int? Kilometraje { get; set; }

        public int? IdMarca { get; set; }

        public int? IdModelo { get; set; }

        public int? Anio { get; set; }

        public string IdCliente { get; set; }
    }
}
