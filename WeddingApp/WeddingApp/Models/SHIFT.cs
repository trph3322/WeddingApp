//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeddingApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SHIFT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SHIFT()
        {
            this.WEDDINGs = new HashSet<WEDDING>();
        }
    
        public int SHIFTID { get; set; }
        public string SHIFTNAME { get; set; }
        public System.TimeSpan STARTTIME { get; set; }
        public System.TimeSpan ENDTIME { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WEDDING> WEDDINGs { get; set; }
    }
}
