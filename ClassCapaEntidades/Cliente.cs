﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassCapaEntidades
{
    public class Cliente
    {
        public int id_cliente { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Celular { get; set; } = "";
        public string TelOficina { get; set; } = "";
        public string Correo { get; set; } = "";
        public string CorreoCorporativo { get; set; } = "";
    }
}
