using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFGesAgro.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/Login
        public ActionResult Login()
        {
            ViewBag.Title = "Seja bem vindo(a)";
            return View();
        }
        // GET: /Home/Index
        public ActionResult Index()
        {
            // return RedirectToAction("Index", "Index");
            return View();
        }

        public ActionResult Index2()
        {
            // return RedirectToAction("Index", "Index");
            return View();
        }

        /*   public ActionResult GeraExcel(string CustoEstimado, string CustEstCod)
           {

               Type tipoEntidade = Type.GetType("ExportacaoExcel.Models." + CustoEstimado);

               return this.Excel(new DBDataContext(),

               this.SelecionaDados(tipoEntidade),

               CustoEstimado + ".xls",

               CustEstCod.Split(','));

           }

           public IQueryable SelecionaDados(Type tb)
           {

               DBDataContext _db = new DBDataContext();

               return _db.GetTable(tb).AsQueryable();

           }
       }*/
    }
      
}
