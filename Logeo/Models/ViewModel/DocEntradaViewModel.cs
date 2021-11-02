using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Documento.Models.ViewModels
{
    public class DocEntradaViewModel
    {
        [Required]
        [Range(1, 100000000000)]

        [Display(Name = "Radicado")]
        public int Radicado_Entrada { get; set; }
        [Required]
        [Display(Name = "Fecha Salida")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Entrada { get; set; }
        [Required]
        [Range(1, 100000000000)]
        [Display(Name = "ID Remitente")]
        public int ID_Remitente { get; set; }

    }

}