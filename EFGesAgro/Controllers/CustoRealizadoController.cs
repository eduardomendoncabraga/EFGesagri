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
    public class CustoRealizadoController : Controller
    {
        private EFGESAGROEntities db = new EFGESAGROEntities();

        //
        // GET: /CustoRealizado/

        public ActionResult Index()
        {
            var CustoReal = db.CustoPrevisto.Include(c => c.Talhao).Include(c =>  c.CustoItens);

            return View(CustoReal.ToList());
        }

        //
        // GET: /CustoRealizado/Details/5

        public ActionResult Details(int CusRealCod = 0)
        {
            CustoPrevisto custoprevisto = db.CustoPrevisto.Find(CusRealCod);
            if (custoprevisto == null)
            {
                return HttpNotFound();
            }
            return View(custoprevisto);
        }

        //
        // GET: /CustoRealizado/Create

        public ActionResult Adicionar()
        {
            ViewBag.NroTlh = new SelectList(db.Talhao, "TlhCod", "TlhDes");
            ViewBag.ItnsCus = new SelectList(db.CustoItens, "CusItm", "CusItmDesc");

            return View();
        }

        //
        // POST: /CustoRealizado/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(CustoPrevisto custorealizado)
        {
            if (ModelState.IsValid)
            {
                db.CustoPrevisto.Add(custorealizado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NroTlh = new SelectList(db.Talhao, "TlhCod", "TlhDes", custorealizado.CusPrevTlhCod);
            ViewBag.ItnsCus = new SelectList(db.CustoItens, "CusItm", "CusItmDesc", custorealizado.CusPrevItm);
            
            return View(custorealizado);
        }

        //
        // GET: /CustoRealizado/Edit/5

        public ActionResult Editar(long CusPrevCod)
        {
            CustoPrevisto custorealizado = db.CustoPrevisto.Find(CusPrevCod);

            ViewBag.NroTlh = new SelectList(db.Talhao, "TlhCod", "TlhDes", custorealizado.CusPrevTlhCod);
            ViewBag.ItnsCus = new SelectList(db.CustoItens, "CusItm", "CusItmDesc", custorealizado.CusPrevItm);

            if (custorealizado == null)
            {
                return HttpNotFound();
            }
            return View(custorealizado);
        }

        //
        // POST: /CustoRealizado/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CustoPrevisto custorealizado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(custorealizado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NroTlh = new SelectList(db.Talhao, "TlhCod", "TlhDes", custorealizado.CusPrevTlhCod);
            ViewBag.ItnsCus = new SelectList(db.CustoItens, "CusItm", "CusItmDesc", custorealizado.CusPrevItm);
            return View(custorealizado);
        }

        //
        // GET: /CustoRealizado/Delete/5

        [HttpPost]
        public string Excluir(long CusPrevCod)
        {
            try
            {
                CustoPrevisto custorealizado = db.CustoPrevisto.Find(CusPrevCod);
                db.CustoPrevisto.Remove(custorealizado);
                db.SaveChanges();
                return Boolean.TrueString;
            }
            catch
            {
                return Boolean.FalseString;
            }
        }
        
        public ActionResult RelarioCustoRealizado()
        {
            ICollection<CustoPrevisto> model = null;
            {
                model = db.CustoPrevisto.AsNoTracking().ToList<CustoPrevisto>();
            }

            ViewAsPdf pdf = new ViewAsPdf();
            
            pdf.IsGrayScale = false;
            pdf.Model = model;
            pdf.PageMargins = new Rotativa.Options.Margins(10, 10, 10, 10);
            pdf.ViewName = "RelarioCustoRealizado";
            return pdf;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}