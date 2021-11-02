using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Documento.Models.ViewModels
{
    public class ListDependencia
    {
        public int IDDependencia { get; set; }
        public string Dependencia { get; set; }
        public int Nivel { get; set; }
    }
}