using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaMecanica.Model
{
    class ConsumoAPIModel
    {
        public string Listar { get; set; }
        public string Obtener { get; set; }
        public string Crear { get; set; }
        public string Actualizar { get; set; }
        public string Eliminar { get; set; }


        public ConsumoAPIModel()
        {
            this.Listar = "";
            this.Obtener = "";
            this.Crear = "";
            this.Actualizar = "";
            this.Eliminar = "";
        }
    }
}
