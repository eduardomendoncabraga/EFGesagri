using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFGesAgro.Models
{
    public class CustoViewModel
    {
        public CustoViewModel()
        {
            ListaCustoTela = new List<CustoTela>();
            ListaCustoTela2 = new List<CustoTela2>();
        }


        //public List<CustoEstimado> CustoEstimado { get; set; }
        //public List<CustoPrevisto> CustoPrevisto { get; set; }

        public List<CustoTela> ListaCustoTela { get; set; }

       public List<CustoTela2> ListaCustoTela2 { get; set; }
        
    }
    public class CustoTela
    {
        public int CusEstCod { get; set; }
        public int CusEstTlhCod { get; set; }
        public decimal CusEstVlr { get; set; }
        public string CusEstObs { get; set; }
        public int CusEstItm { get; set; }

        public virtual CustoItens CustoItens { get; set; }
        public virtual Talhao Talhao { get; set; }
    }

     public class CustoTela2
    {
        public int CusPrevCod { get; set; }
        public int CusPrevTlhCod { get; set; }
        public int CusPrevItm { get; set; }
        public string CusPrevObs { get; set; }
        public decimal CusPrevVlr { get; set; }

        public virtual CustoItens CustoItens { get; set; }
        public virtual Talhao Talhao { get; set; }
    }

}