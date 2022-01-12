using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq.Expressions;
using EFGesAgro.Models;
using System.Data;
using System.Net;
using Rotativa;

namespace EFGesAgro.Controllers
{
    public class CulturaController : Controller
    {
        //
        // GET: /Cultura/
        private EFGESAGROEntities db = new EFGESAGROEntities();
        public ActionResult Index(int ? pagina) //listagens grid tela incial work
        {
            var culturas = db.Cultura.ToList();
            
            return View(culturas);
        }

        public ActionResult Adicionar(){           

            return View();
        }
        [HttpPost]
        public ActionResult Adicionar(Cultura cultura)
        {
            if (ModelState.IsValid)
            {
                db.Cultura.Add(cultura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(cultura);
        }

        public ActionResult Editar(int CulCod = 0)
        {
            Cultura cultura = db.Cultura.Find(CulCod);

            return View(cultura);
        }


        [HttpPost]
        public ActionResult Editar(Cultura cultura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cultura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cultura);

        }
       /* public ActionResult Excluir(int CulCod = 0)
        {
            Cultura cultura = db.Cultura.Find(CulCod);

            if (cultura == null)
            {
                return HttpNotFound();
            }


            return View(cultura);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DeleteConfirmed(int CulCod)
        {

            Cultura cultura = db.Cultura.Find(CulCod);

            db.Cultura.Remove(cultura);

            db.SaveChanges();

            return RedirectToAction("Index");
        }*/
        [HttpPost]
        public string Excluir(long CulCod)
        {
            try
            {
                Cultura cultura = db.Cultura.Find(CulCod);
                db.Cultura.Remove(cultura);
                db.SaveChanges();
                return Boolean.TrueString;
            }
            catch
            {
                return Boolean.FalseString;
            }
        }


        public ActionResult Detalhes(int? CulCod)
        {
            if (CulCod == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cultura cultura = db.Cultura.Find(CulCod);
            if (cultura == null)
            {
                return HttpNotFound();
            }
            return View(cultura);
        }

        public ActionResult CulturaLista()
        {
            ICollection<Cultura> model = null;
            {
                model = db.Cultura.AsNoTracking().ToList<Cultura>();
            }

            ViewAsPdf pdf = new ViewAsPdf();
            pdf.IsGrayScale = true;
            pdf.Model = model;
            pdf.PageMargins = new Rotativa.Options.Margins(10, 10, 10, 10);
            pdf.ViewName = "CulturaLista";
            return pdf;
        }



    }
}
