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
    using System.ComponentModel.DataAnnotations;

    public partial class picture
    {
        [Key]
        public int news_newsid { get; set; }
        public int pictureid { get; set; }
        public byte[] picture1 { get; set; }
    
        public virtual news news { get; set; }
    }
}
