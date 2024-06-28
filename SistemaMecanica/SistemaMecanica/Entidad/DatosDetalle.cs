using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaMecanica.Entidad
{
    public class DatosDetalle
    {
        public Cliente Cliente { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public List<Tarea> Tareas { get; set; }
    }
}
