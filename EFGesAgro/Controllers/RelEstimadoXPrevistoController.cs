using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using EFGesAgro.Models;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Web.UI;
using System.Web.Mvc;


namespace EFGesAgro.Controllers
{
    public class RelEstimadoXPrevistoController : Controller
    {

        private EFGESAGROEntities db = new EFGESAGROEntities();
        //
        // GET: /RelEstimadoXPrevisto/

        [HttpPost]
        public ActionResult Rela()
        {
          //Stream output
          string fileName = Guid.NewGuid() + ".pdf";
          string filePath = Path.Combine(Server.MapPath("~/PDFs"), fileName);


          Document documento = new Document (PageSize.A4, 2,2,2,2);

          Paragraph p = new Paragraph("Relatório custo estimado");
          p.Alignment = 50;

          try
          {
              PdfWriter.GetInstance(documento, new FileStream(filePath, FileMode.Create));

              PdfPTable pdftab = new PdfPTable(4);
              pdftab.HorizontalAlignment = 1;
              pdftab.SpacingBefore = 20f;
              pdftab.SpacingAfter = 20f;

              List<CustoEstimado> data = new List<Models.CustoEstimado>();
              using (EFGESAGROEntities db = new EFGESAGROEntities())
              {
                  data = db.CustoEstimado.OrderBy(a => a.CusEstCod).ThenBy(a => a.CusEstItm).ToList();
              }

              foreach (var item in data)
              {
                  pdftab.AddCell(item.CusEstCod.ToString());
                  pdftab.AddCell(item.Talhao.TlhDes.ToString());
                  pdftab.AddCell(item.CustoItens.CusItmDesc.ToString());
                  pdftab.AddCell(item.CusEstVlr.ToString());

              }
              documento.Open();
              documento.Add(p);
              documento.Add(pdftab);
              documento.Close();

              byte[] content = System.IO.File.ReadAllBytes(filePath);
              HttpContext context = System.Web.HttpContext.Current;

              context.Response.BinaryWrite(content);
              context.Response.ContentType = "application/pdf";
              context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
              context.Response.End();
          }
          catch (Exception e)
          {
              throw;
          }
          finally
          {
              documento.Close();
          }

          return View();
        }


       /* [HttpPost]
        public FileContentResult Generate(GenerateModel m)
        {
            DiplomaPrinter printer =
              new DiplomaPrinter(m.Name, m.Distance, m.Date, m.RaceName, m.ShowRulers);
            MemoryStream memoryStream = new MemoryStream();
            printer.Create(memoryStream);

            return File(memoryStream.GetBuffer(), "application/pdf", "diploma.pdf");
        }*/

    }
}
