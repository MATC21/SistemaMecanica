using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaMecanica.Entidad
{
    class MarcaAutomovil
    {
        public int IdMarca { get; set; }

        public string Marca { get; set; }

        public virtual ICollection<ModeloAutomovil> ModeloVehiculos { get; set; } = new List<ModeloAutomovil>();

        public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
    }
}
