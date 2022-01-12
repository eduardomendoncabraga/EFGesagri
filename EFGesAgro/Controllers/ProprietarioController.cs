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
using System.Web.Script.Serialization;

namespace EFGesAgro.Controllers
{
    public class ProprietarioController : Controller
    {
        
        //
        // GET: /Proprietario/
        private EFGESAGROEntities db = new EFGESAGROEntities();

        public ActionResult Index(int? pagina){
   
            var proprietarios = db.Pessoa.Include(p => p.Cidade).Include(p => p.Estado).ToList();  
      
            return View(proprietarios);

            
        }

        public ActionResult Adicionar(){

            ViewBag.CidCodList = new SelectList(db.Cidade.OrderBy(c => c.CidNom), "CidCod", "CidNom");
            ViewBag.EstCodList = new SelectList(db.Estado.OrderBy(e => e.EstNom), "EstCod", "EstNom");
   
 
            return View();
        }
        
        
        [HttpPost]
        public ActionResult Adicionar(Pessoa proprietario){//Pessoa Tabela pessoa onde representa um - Proprietario
            if (ModelState.IsValid){
                db.Pessoa.Add(proprietario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CidCodList = new SelectList(db.Cidade.OrderBy(c => c.CidNom), "CidCod", "CidNom", proprietario.CidCod);
            ViewBag.EstCodList = new SelectList(db.Estado.OrderBy(e => e.EstNom), "EstCod", "EstNom", proprietario.EstCod);

            return View(proprietario);
        }

        public ActionResult Editar(int PesCod){
            
            Pessoa proprietario = db.Pessoa.Find(PesCod);

            ViewBag.CidCodList = new SelectList(db.Cidade.OrderBy(c => c.CidNom), "CidCod", "CidNom", proprietario.CidCod);
            ViewBag.EstCodList = new SelectList(db.Estado.OrderBy(e => e.EstNom), "EstCod", "EstNom", proprietario.EstCod);
               
            return View(proprietario);
        }

        [HttpPost] 
        public ActionResult Editar(Pessoa proprietario) 
        {

            if (ModelState.IsValid) { 
                db.Entry(proprietario).State = EntityState.Modified;
                db.SaveChanges(); 
                return RedirectToAction("Index");
            }
            ViewBag.CidCodList = new SelectList(db.Cidade.OrderBy(c => c.CidNom), "CidCod", "CidNom", proprietario.CidCod);
            ViewBag.EstCodList = new SelectList(db.Estado.OrderBy(e => e.EstNom), "EstCod", "EstNom", proprietario.EstCod);        

            return View(proprietario);

        }

        public ActionResult Excluir(int PesCod = 0){


            Pessoa proprietario = db.Pessoa.Find(PesCod);

            if (proprietario == null)
            {
                return HttpNotFound();
            }
            ViewBag.CidCodList = new SelectList(db.Cidade.OrderBy(c => c.CidNom), "CidCod", "CidNom", proprietario.CidCod);
            ViewBag.EstCodList = new SelectList(db.Estado.OrderBy(e => e.EstNom), "EstCod", "EstNom", proprietario.EstCod);

            return View(proprietario);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmed(int PesCod)
        {

            Pessoa proprietario = db.Pessoa.Find(PesCod);
            db.Pessoa.Remove(proprietario);        
            db.SaveChanges();

            ViewBag.CidCodList = new SelectList(db.Cidade.OrderBy(c => c.CidNom), "CidCod", "CidNom", proprietario.CidCod);
            ViewBag.EstCodList = new SelectList(db.Estado.OrderBy(e => e.EstNom), "EstCod", "EstNom", proprietario.EstCod);
        
            return RedirectToAction("Index");
        }
    }
}
