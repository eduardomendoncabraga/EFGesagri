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
    public class FazendaController : Controller
    {
        private EFGESAGROEntities db = new EFGESAGROEntities();

        //
        // GET: /Fazenda/

        public ActionResult Index()
        {
            var fazenda = db.Fazenda.Include(f => f.Cidade).Include(f => f.Estado).Include(f => f.Pessoa);

            return View(fazenda.ToList());
        }
       
        //
        // GET: /Fazenda/Create

        public ActionResult Adicionar()
        {
            ViewBag.FazCidList = new SelectList(db.Cidade, "CidCod", "CidNom");
            ViewBag.FazEstList = new SelectList(db.Estado, "EstCod", "EstSig");
            ViewBag.FazPesList = new SelectList(db.Pessoa, "PesCod", "PesNom");

            return View();
        }

        //
        // POST: /Fazenda/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(Fazenda fazenda)
        {
            if (ModelState.IsValid)
            {
                db.Fazenda.Add(fazenda);
                db.SaveChanges();
               return RedirectToAction("Index");
            }
            ViewBag.FazCidList = new SelectList(db.Cidade, "CidCod", "CidNom", fazenda.FazCid);
            ViewBag.FazEstList = new SelectList(db.Estado, "EstCod", "EstSig", fazenda.FazEst);
            ViewBag.FazPesList = new SelectList(db.Pessoa, "PesCod", "PesNom", fazenda.FazPes);

            return View(fazenda);
        }

        //
        // GET: /Fazenda/Edit/5

        public ActionResult Editar(int FazCod = 0)
        {
            Fazenda fazenda = db.Fazenda.Find(FazCod);

            ViewBag.FazCidList = new SelectList(db.Cidade, "CidCod", "CidNom", fazenda.FazCid);
            ViewBag.FazEstList = new SelectList(db.Estado, "EstCod", "EstSig", fazenda.FazEst);
            ViewBag.FazPesList = new SelectList(db.Pessoa, "PesCod", "PesNom", fazenda.FazPes);


           /* if (fazenda == null)
            {
                return HttpNotFound();
            }
            */
            return View(fazenda);
        }

        //
        // POST: /Fazenda/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Fazenda fazenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fazenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FazCidList = new SelectList(db.Cidade, "CidCod", "CidNom", fazenda.FazCid);
            ViewBag.FazEstList = new SelectList(db.Estado, "EstCod", "EstSig", fazenda.FazEst);
            ViewBag.FazPesList = new SelectList(db.Pessoa, "PesCod", "PesNom", fazenda.FazPes);

            return View(fazenda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Excluir(long FazCod)
        {
            try
            {
                Fazenda fazenda = db.Fazenda.Find(FazCod);
                db.Fazenda.Remove(fazenda);
                db.SaveChanges();
                return Boolean.TrueString;
            }
            catch
            {
                return Boolean.FalseString;
            }
        }

        /* POST: /Fazenda/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fazenda fazenda = db.Fazenda.Find(id);
            db.Fazenda.Remove(fazenda);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //
        // GET: /Fazenda/Details/5

        public ActionResult Detalhes(int FazCod = 0)
        {
            Fazenda fazenda = db.Fazenda.Find(FazCod);
            if (fazenda == null)
            {
                return HttpNotFound();
            }
            return View(fazenda);
        }

    }
}