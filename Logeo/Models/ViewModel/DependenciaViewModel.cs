using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Documento.Models.ViewModels
{
    public class DependenciaViewModel
    {
        [Required]
        [Range(1, 100000000000)]
        [Display(Name = "ID Dependencia")]
        public int IDDependencia { get; set; }
        [Required]
        [StringLength(100)]

        [Display(Name = "Dependencia")]
        public string Dependencia { get; set; }
        [Required]
        [Range(1, 5)]
        [Display(Name = "Nivel")]
        public int Nivel { get; set; }

    }
}