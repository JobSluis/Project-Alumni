//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlumniDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class cours
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cours()
        {
            this.usercourses = new HashSet<usercours>();
        }
    
        public int courseid { get; set; }
        public string NAME { get; set; }
        public int addresses_addressid { get; set; }
    
        public virtual address address { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usercours> usercourses { get; set; }
    }
}
