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
    
    public partial class DISH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DISH()
        {
            this.MENUS = new HashSet<MENU>();
        }
    
        public int DISHID { get; set; }
        public string DISHNAME { get; set; }
        public decimal DISHCOST { get; set; }
        public string DISHDESCRIPTION { get; set; }
        public string DISHIMAGE { get; set; }
        public int DISHTYPEID { get; set; }
        public Nullable<byte> STATUS { get; set; }
    
        public virtual DISHTYPE DISHTYPE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENU> MENUS { get; set; }
    }
}
