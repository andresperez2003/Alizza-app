//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Logeo.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCiudadDpto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCiudadDpto()
        {
            this.tblUsuarioCorrespondencia = new HashSet<tblUsuarioCorrespondencia>();
        }
    
        public int idCiudad { get; set; }
        public string ciudad { get; set; }
        public string departamento { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUsuarioCorrespondencia> tblUsuarioCorrespondencia { get; set; }
    }
}
