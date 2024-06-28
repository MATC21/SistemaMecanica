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
            this.Listar = "http://192.168.70.113:45455/api";
            this.Obtener = "http://192.168.70.113:45455/api";
            this.Crear = "http://192.168.70.113:45455/api";
            this.Actualizar = "http://192.168.70.113:45455/api";
            this.Eliminar = "http://192.168.70.113:45455/api";
        }
    }
}
