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
    public class VariedadeController : Controller
    {
        private EFGESAGROEntities db = new EFGESAGROEntities();

        //
        // GET: /Variedade/

        public ActionResult Index()
        {
            var variedade = db.Variedade.Include(v => v.Cultura);
            return View(variedade.ToList());
        }

        //
        // GET: /Variedade/Details/5

        public ActionResult Detalhes(int id = 0)
        {
            Variedade variedade = db.Variedade.Find(id);
            if (variedade == null)
            {
                return HttpNotFound();
            }
            return View(variedade);
        }

        //
        // GET: /Variedade/Create

        public ActionResult Adicionar()
        {
            ViewBag.CulCod = new SelectList(db.Cultura, "CulCod", "CulNom");
            return View();
        }

        //
        // POST: /Variedade/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(Variedade variedade)
        {
            if (ModelState.IsValid)
            {
                db.Variedade.Add(variedade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CulCod = new SelectList(db.Cultura, "CulCod", "CulNom", variedade.CulCod);
            return View(variedade);
        }

        //
        // GET: /Variedade/Edit/5

        public ActionResult Editar(int VdeCod = 0)
        {
            Variedade variedade = db.Variedade.Find(VdeCod);
           
            ViewBag.CulCod = new SelectList(db.Cultura, "CulCod", "CulNom", variedade.CulCod);

            return View(variedade);
        }

        //
        // POST: /Variedade/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Variedade variedade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(variedade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CulCod = new SelectList(db.Cultura, "CulCod", "CulNom", variedade.CulCod);
            return View(variedade);
        }

        //
        // GET: /Variedade/Delete/5

        [HttpPost]
        public string Excluir(long VdeCod)
        {
            try
            {
                Cultura cultura = db.Cultura.Find(VdeCod);
                db.Cultura.Remove(cultura);
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