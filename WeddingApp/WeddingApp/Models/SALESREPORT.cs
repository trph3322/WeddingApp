//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeddingApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class SALESREPORT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SALESREPORT()
        {
            this.REPORTDETAILs = new HashSet<REPORTDETAIL>();
        }
    
        public System.DateTime REPORTMONTH { get; set; }
        public Nullable<short> BOOKEDWEDDING { get; set; }
        public Nullable<short> PAIDWEDDING { get; set; }
        public Nullable<decimal> PROFIT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REPORTDETAIL> REPORTDETAILs { get; set; }
    }
}
