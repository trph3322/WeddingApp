//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeddingApp.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class BALLROOM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BALLROOM()
        {
            this.WEDDINGs = new HashSet<WEDDING>();
        }
    
        public int BALLROOMID { get; set; }
        public string BALLROOMNAME { get; set; }
        public short MAXIMUMTABLE { get; set; }
        public string BALLROOMIMAGE { get; set; }
        public string BALLROOMDESCRIPTION { get; set; }
        public int TYPEID { get; set; }
        public string NOTE { get; set; }
    
        public virtual BALLROOMTYPE BALLROOMTYPE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WEDDING> WEDDINGs { get; set; }
    }
}
