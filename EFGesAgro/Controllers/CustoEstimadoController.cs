using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFGesAgro.Models;
using Rotativa;

namespace EFGesAgro.Controllers
{
    public class CustoEstimadoController : Controller
    {
        private EFGESAGROEntities db = new EFGESAGROEntities();
        

        
        //
        // GET: /CustoEstimado/

        public ActionResult Index()
        {
            var CustoEst = db.CustoEstimado.Include(c => c.Talhao).Include(c => c.CustoItens);

            ViewBag.Tot += new SelectList(db.CustoEstimado, "CustEstCod", "CustEstVlr");

           
           
            //var dados = from d in db.Talhao select d;

            return View(CustoEst.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            CustoEstimado CustoEst = db.CustoEstimado.Find(id);

            
            if (CustoEst == null)
            {
                return HttpNotFound();
            }
            return View(CustoEst);
        }

        //
        // GET: /CustoEstimado/Create

        public ActionResult Adicionar()
        {
            ViewBag.NroTlh  = new SelectList(db.Talhao, "TlhCod", "TlhDes");
            ViewBag.ItnsCus = new SelectList(db.CustoItens, "CusItm", "CusItmDesc");

           
           // var dados = from d in db.Talhao select d;

            // CustoEst var CustoEst = db.CustoEstimado.Include(c => c.Talhao).Include(c => c.CustoItens);

            return View();
        }

        //
        // POST: /CustoEstimado/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(CustoEstimado CustoEst)
        {
            if (ModelState.IsValid)
            {
                db.CustoEstimado.Add(CustoEst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NroTlh  = new SelectList(db.Talhao, "TlhCod", "TlhDes", CustoEst.CusEstTlhCod);
            ViewBag.ItnsCus = new SelectList(db.CustoItens, "CusItm", "CusItmDesc", CustoEst.CusEstItm);
            return View(CustoEst);
        }

        //
        // GET: /CustoEstimado/Edit/5

        public ActionResult Editar(long CusEstCod)
        {
            CustoEstimado CusEst = db.CustoEstimado.Find(CusEstCod);

            ViewBag.NroTlh = new SelectList(db.Talhao, "TlhCod", "TlhDes", CusEst.CusEstTlhCod);
            ViewBag.ItnsCus = new SelectList(db.CustoItens, "CusItm", "CusItmDesc", CusEst.CusEstItm);

            
            /* if (custoestimado == null)
            {
                return HttpNotFound();
            }*/
            return View(CusEst);
        }

        //
        // POST: /CustoEstimado/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CustoEstimado CusEst)
        {
            if (ModelState.IsValid)
            {
                db.Entry(CusEst).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NroTlh = new SelectList(db.Talhao, "TlhCod", "TlhDes", CusEst.CusEstTlhCod);
            ViewBag.ItnsCus = new SelectList(db.CustoItens, "CusItm", "CusItmDesc", CusEst.CusEstItm);

            return View(CusEst);
        }

        //
        // GET: /CustoEstimado/Delete/5

        [HttpPost]
        public string Excluir(long CusEstCod)
        {
            try
            {
                CustoEstimado CustEsti = db.CustoEstimado.Find(CusEstCod);
                db.CustoEstimado.Remove(CustEsti);
                db.SaveChanges();
                return Boolean.TrueString;
            }
            catch
            {
                return Boolean.FalseString;
            }
        }

        [AllowAnonymous]
        public ActionResult RelarioCustoEstimado()
        {
            ICollection<CustoEstimado> model = null;
            {
                model = db.CustoEstimado.AsNoTracking().ToList<CustoEstimado>();
            }

            ViewAsPdf pdf = new ViewAsPdf();
           
            pdf.IsGrayScale = true;
            pdf.Model = model;
            //pdf.CustomHeaders = 
            pdf.PageMargins = new Rotativa.Options.Margins(10, 10, 10, 10);
            pdf.ViewName = "RelarioCustoEstimado";
            return pdf;
        }

       
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}