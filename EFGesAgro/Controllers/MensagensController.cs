using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFGesAgro.Controllers
{
    public class MensagensController : Controller
    {
        //
        // GET: /Menssangens/

        public ActionResult BomDia()
        {
            return Content("Bom dia... hoje voce acordou cedo!");

        }

        public ActionResult BoaTarde()
        {
            return Content("Boa tarde..... não durma na mesa de trabalho!");
        }

    }
}
