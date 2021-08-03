using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCapaEntidades
{
    public class Reparacion
    {
        //Entidad Reparación: Propiedades y atributos
        public int Id_Reparacion { get; set; }
        public string Detalles { get; set; }
        public string Garantia { get; set; }
        public DateTime salida { get; set; }
        public int FK_Revision { get; set; }



    }
}
