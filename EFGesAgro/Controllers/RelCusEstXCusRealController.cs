using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using EFGesAgro.Models;

namespace EFGesAgro.Controllers
{
    public class RelCusEstXCusRealController : Controller
    {
        //
        // GET: /RelCusEstXCusReal/
        private EFGESAGROEntities db = new EFGESAGROEntities();
       
        public ActionResult RelatoriosXCustos()
        {
            return View();
        }

        public ActionResult XPrevisto()
        {
            ICollection<CustoPrevisto> model2 = null;
            {

                model2 = db.CustoPrevisto.AsNoTracking().ToList<CustoPrevisto>();
            }

            ViewAsPdf pdf = new ViewAsPdf();
            pdf.IsGrayScale = true;
            pdf.Model = model2;
            pdf.PageMargins = new Rotativa.Options.Margins(10, 10, 10, 10);
            pdf.ViewName = "RelCustos";
            return pdf;
        }

        public ActionResult XEstimado()
        {

            ICollection<CustoEstimado> model = null;
            {
                model = db.CustoEstimado.AsNoTracking().ToList<CustoEstimado>();
              
            }

            ViewAsPdf pdf = new ViewAsPdf();
            pdf.IsGrayScale = true;
            pdf.Model = model;
            pdf.PageMargins = new Rotativa.Options.Margins(10, 10, 10, 10);
            pdf.ViewName = "RelCustos";
            return pdf;
        }

    }
}
