using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Documento.Models.ViewModels
{
    public class ListDocEntrada
    {
        public int Radicado_Entrada { get; set; }
        public DateTime Fecha_Entrada { get; set; }
        public int ID_Remitente { get; set; }
    }
}