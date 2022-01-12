using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EFGesAgro.Models
{
    public partial class RelCustos
    {
        
        public int CusPrevCod { get; set; }
        public int CusPrevTlhCod { get; set; }
        public int CusPrevItm { get; set; }
        public string CusPrevObs { get; set; }
        public decimal CusPrevVlr { get; set; }
        public int CusEstCod { get; set; }
        public int CusEstTlhCod { get; set; }
        public decimal CusEstVlr { get; set; }
        public string CusEstObs { get; set; }
        public int CusEstItm { get; set; }

        public virtual CustoItens CustoItens { get; set; }
        public virtual Talhao Talhao { get; set; }

    }
}