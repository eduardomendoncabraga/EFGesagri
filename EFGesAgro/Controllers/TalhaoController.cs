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
    public class TalhaoController : Controller
    {
        private EFGESAGROEntities db = new EFGESAGROEntities();

        public ActionResult Index()
        {
            var talhao = db.Talhao.Include(t => t.Fazenda).Include(t => t.Cultura).Include(t => t.Variedade).Include(t => t.Safra);
            return View(talhao.ToList());
        }


        //
        // GET: /Talhao/Adicionar

        public ActionResult Adicionar()
        {
            ViewBag.FazCodList     = new SelectList(db.Fazenda, "FazCod", "FazNom");
            ViewBag.CulCodList     = new SelectList(db.Cultura, "CulCod", "CulNom");
            ViewBag.VdeCodList     = new SelectList(db.Variedade, "VdeCod", "VdeNom");
            ViewBag.TlhSfrCodList  = new SelectList(db.Safra, "SfrCod", "SfrDesc");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(Talhao talhao)
        {
            if (ModelState.IsValid)
            {
                db.Talhao.Add(talhao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FazCodList    = new SelectList(db.Fazenda, "FazCod", "FazNom", talhao.TlhFazCod);
            ViewBag.CulCodList    = new SelectList(db.Cultura, "CulCod", "CulNom", talhao.CulCod);
            ViewBag.VdeCodList    = new SelectList(db.Variedade, "VdeCod", "VdeNom", talhao.VdeCod);
            ViewBag.TlhSfrCodList = new SelectList(db.Safra, "SfrCod", "SfrDesc" , talhao.TlhSfrCod);

            return View(talhao);
        }

        //
        // GET: /Talhao/Editar/

        public ActionResult Editar(long TlhCod)
        {
            Talhao talhao = db.Talhao.Find(TlhCod);

            ViewBag.FazCodList    = new SelectList(db.Fazenda, "FazCod", "FazNom", talhao.TlhFazCod);
            ViewBag.CulCodList    = new SelectList(db.Cultura, "CulCod", "CulNom", talhao.CulCod);
            ViewBag.VdeCodList    = new SelectList(db.Variedade, "VdeCod", "VdeNom", talhao.VdeCod);
            ViewBag.TlhSfrCodList = new SelectList(db.Safra, "SfrCod", "SfrDesc", talhao.TlhSfrCod);

            return View(talhao);
        }

        //
        // POST: /Talhao/Editar/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Talhao talhao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talhao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FazCodList    = new SelectList(db.Fazenda, "FazCod", "FazNom", talhao.TlhFazCod);
            ViewBag.CulCodList    = new SelectList(db.Cultura, "CulCod", "CulNom", talhao.CulCod);
            ViewBag.VdeCodList    = new SelectList(db.Variedade, "VdeCod", "VdeNom", talhao.VdeCod);
            ViewBag.TlhSfrCodList = new SelectList(db.Safra, "SfrCod", "SfrDesc", talhao.TlhSfrCod);

            return View(talhao);
        }

        [HttpPost]
        public string Excluir(long TlhCod)
        {
            try
            {
                Talhao talhao = db.Talhao.Find(TlhCod);
                db.Talhao.Remove(talhao);
                db.SaveChanges();
                return Boolean.TrueString;
            }
            catch
            {
                return Boolean.FalseString;
            }
        }
        
        //
        // GET: /Talhao/Detalhes/

        public ActionResult Detalhes(int TlhCod = 0)
        {
            Talhao talhao = db.Talhao.Find(TlhCod);
            if (talhao == null)
            {
                return HttpNotFound();
            }
            return View();
        }
       
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}