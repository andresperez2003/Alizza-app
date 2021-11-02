using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Documento.Models.ViewModels
{
    public class DocSalidaViewModel
    {
        [Required]
        [Range(1, 100000000000)]
        [Display(Name = "Radicado")]
        public int Radicado_Salida { get; set; }
        [Required]
        [Range(1, 100000000000)]

        [Display(Name = "Dependencia")]
        public int ID_Dependencia { get; set; }
        [Required]
        [Range(1, 100000000000)]
        [Display(Name = "Destinatario")]
        public int ID_Destinatario { get; set; }
        [Required]
        [Display(Name = "Fecha Salida")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Salida { get; set; }
    }
}