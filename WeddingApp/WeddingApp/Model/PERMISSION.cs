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
    
    public partial class PERMISSION
    {
        public int PERMISSIONID { get; set; }
        public string ROLEID { get; set; }
        public int FUNCTIONID { get; set; }
    
        public virtual FUNCTION FUNCTION { get; set; }
        public virtual ROLE ROLE { get; set; }
    }
}