//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectAlumni.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class news
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public news()
        {
            this.pictures = new HashSet<picture>();
        }
    
        public int newsid { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public string users_userid { get; set; }
        public System.DateTime date { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<picture> pictures { get; set; }
    }
}
