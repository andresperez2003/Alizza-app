using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Documento.Models.ViewModels
{
    public class CiudadDptoViewModel
    {
        [Required]
        [Range(1, 100000000000)]

        [Display(Name = "ID Ciudad")]
        public int IDCiudad { get; set; }
        [Required]
        [Display(Name = "Ciudad")]
        [StringLength(100)]
        public string Ciudad { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Departamento")]
        public string Departamento { get; set; }
    }
}