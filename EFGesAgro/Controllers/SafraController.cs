using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFGesAgro.Models;

namespace EFGesAgro.Controllers
{
    public class SafraController : Controller
    {
        private EFGESAGROEntities db = new EFGESAGROEntities();

        //
        // GET: /Safra/

        public ActionResult Index(int ? SfrCod)
        {
            var safras = db.Safra.ToList();

            return View(safras);
        }

        //
        // GET: /Safra/Adicionar

        public ActionResult Adicionar()
        {
            return View();
        }

        //
        // POST: /Safra/Adicionar

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(Safra safra)
        {
            if (ModelState.IsValid)
            {
                db.Safra.Add(safra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(safra);
        }

        //
        // GET: /Safra/Editar/5

        public ActionResult Editar(int SfrCod = 0)
        {
            Safra safra = db.Safra.Find(SfrCod);
      
            return View();
        }

        //
        // POST: /Safra/Editar/5

        [HttpPost]
        public ActionResult Editar(Safra safra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(safra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(safra);
        }

        [HttpPost]
        public string Excluir(long SfrCod)
        {
            try
            {
                Safra safra = db.Safra.Find(SfrCod);
                db.Safra.Remove(safra);
                db.SaveChanges();
                return Boolean.TrueString;
            }
            catch
            {
                return Boolean.FalseString;
            }
        }

        protected override void Dispose(bool disposing)
         {
             db.Dispose();
             base.Dispose(disposing);
         }
    }
}