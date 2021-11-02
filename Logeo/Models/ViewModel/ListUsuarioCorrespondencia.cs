using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Documento.Models.ViewModels
{
    public class ListUsuarioCorrespondencia
    {
        public int ID { get; set; }
        public string NombreRazonSocial { get; set; }
        public string Direccion { get; set; }
        public int IDCiudad { get; set; }
    }
}