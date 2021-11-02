using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Documento.Models.ViewModels
{
    public class TablaViewModel
    {
        [Required]
        [Range(1, 100000000000)]

        [Display(Name = "Radicado")]
        public int Radicado { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }
        [Required]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

    }
}