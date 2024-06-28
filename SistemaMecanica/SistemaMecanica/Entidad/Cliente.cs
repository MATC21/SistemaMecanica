using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaMecanica.Entidad
{
    public class Cliente
    {
        public string IdCliente { get; set; }

        public string Nombres { get; set; } 

        public string Apellidos { get; set; } 

        public string Telefono { get; set; }

        public string Ubicacion { get; set; }

        //public virtual ICollection<HistorialTarea> HistorialTareas { get; set; } = new List<HistorialTarea>();

        //public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
    }
}
