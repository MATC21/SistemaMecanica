using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaMecanica.Entidad
{
    public class Tarea
    {
        public int IdTarea { get; set; }

        public string Descripcion { get; set; }

        public int? KilometrajeProximoCambio { get; set; }

    }
}
