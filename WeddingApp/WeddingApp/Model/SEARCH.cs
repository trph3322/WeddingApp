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
    
    public partial class SEARCH
    {
        public int HALLID { get; set; }
        public int SHIFTID { get; set; }
        public byte AVAILABLE { get; set; }
    
        public virtual HALL HALL { get; set; }
        public virtual SHIFT SHIFT { get; set; }
    }
}
