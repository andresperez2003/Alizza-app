using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Documento.Models.ViewModels
{
    public class UsuarioCorrespondenciaViewModel
    {
        [Required]
        [Range(1, 100000000000)]
        [Display(Name = "ID ")]
        public int ID { get; set; }
        [Required]
        [StringLength(100)]

        [Display(Name = "Razon Social")]
        public string NombreRazonSocial { get; set; }
        [Required]
        [StringLength(100)]

        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [Required]
        [Range(1, 5)]
        [Display(Name = "ID Ciudad")]
        public int IDCiudad { get; set; }
    }
}