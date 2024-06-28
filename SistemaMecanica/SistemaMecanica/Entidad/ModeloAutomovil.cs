using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaMecanica.Entidad
{
    class ModeloAutomovil
    {
        public int IdModelo { get; set; }

        public string Modelo { get; set; }

        public int? IdMarca { get; set; }

        public virtual MarcaAutomovil IdMarcaNavigation { get; set; }

        public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
    }
}
