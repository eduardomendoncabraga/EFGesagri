//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFGesAgro.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustoItens
    {
        public CustoItens()
        {
            this.CustoEstimado = new HashSet<CustoEstimado>();
            this.CustoPrevisto = new HashSet<CustoPrevisto>();
        }
    
        public int CusItm { get; set; }
        public string CusItmDesc { get; set; }
        public int CusItmOrd { get; set; }
        public string CusItmTip { get; set; }
    
        public virtual ICollection<CustoEstimado> CustoEstimado { get; set; }
        public virtual ICollection<CustoPrevisto> CustoPrevisto { get; set; }
    }
}
