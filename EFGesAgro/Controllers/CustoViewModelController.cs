using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFGesAgro.Models;

namespace EFGesAgro.Controllers
{
    public class CustoViewModelController : Controller
    {
        private EFGESAGROEntities db = new EFGESAGROEntities();
        //
        // GET: /CustoViewModel/

        public ActionResult Index(CustoViewModel CustoViewModel)
        {
            //Nova lista pegando do banco de dados            
            var ListaA = db.CustoEstimado.ToList();

            var ListB   = db.CustoPrevisto.ToList();

           // var listad = CustoViewModel.CustoEstimado.ToList();
          //  var listaf = CustoViewModel.CustoPrevisto.ToList();

            for (int i = 0; i < ListaA.Count; i++)
            {
                CustoTela custo = new CustoTela();
                custo.CusEstCod = ListaA[i].CusEstCod;
                custo.CusEstItm = ListaA[i].CusEstItm;
                custo.CusEstVlr = ListaA[i].CusEstVlr;
                //Falta Talhão e CustoItem
               
                // faz isso em todas as propriedades das duas listas

                CustoViewModel.ListaCustoTela.Add(custo);

            }

            for (int i = 0; i < ListB.Count; i++)
            {
                CustoTela2 custo2 = new CustoTela2();
                custo2.CusPrevCod = ListB[i].CusPrevCod;
                custo2.CusPrevItm = ListB[i].CusPrevItm;
                custo2.CusPrevVlr = ListB[i].CusPrevVlr;

                //Falta Talhão e CustoItem

                // faz isso em todas as propriedades das duas listas

                CustoViewModel.ListaCustoTela2.Add(custo2);

            }
            
            return View(CustoViewModel);
        }

    }
}
