using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Documento.Models.ViewModels
{
    public class ListDocSalida
    {
        public int Radicado_Salida { get; set; }
        public int IDDependencia { get; set; }
        public int IDDestinatario { get; set; }
        public DateTime FechaSalida { get; set; }
    }
}