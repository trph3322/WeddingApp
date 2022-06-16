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
    
    public partial class WEDDING
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WEDDING()
        {
            this.INVOICES = new HashSet<INVOICE>();
            this.MENUs = new HashSet<MENU>();
            this.SERVEs = new HashSet<SERVE>();
        }
    
        public int WEDDINGID { get; set; }
        public string GROOM { get; set; }
        public string BRIDE { get; set; }
        public string TELEPHONE { get; set; }
        public decimal DEPOSIT { get; set; }
        public System.DateTime WEDDINGDATE { get; set; }
        public byte TABLEAMOUNT { get; set; }
        public Nullable<byte> RESERVEAMOUNT { get; set; }
        public Nullable<System.DateTime> BOOKINGDATE { get; set; }
        public int BALLROOMID { get; set; }
        public int SHIFTID { get; set; }
    
        public virtual BALLROOM BALLROOM { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVOICE> INVOICES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENU> MENUs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SERVE> SERVEs { get; set; }
        public virtual SHIFT SHIFT { get; set; }
    }
}
