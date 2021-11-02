
using Documento.Models.ViewModels;
using Logeo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Documento.Controllers
{
    public class DocEntradaController : Controller
    {
        // GET: DocEntrada
        public ActionResult Index()
        {
            List<ListDocEntrada> lst;
            using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
            {
                lst = (from d in db.tblDocEntrada
                       select new ListDocEntrada
                       {
                           Radicado_Entrada = d.radicado,
                           Fecha_Entrada = d.fechaEntrada,
                           ID_Remitente = d.idRemitente
                       }).ToList();
            }
            return View(lst);


        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(DocEntradaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
                    {
                        var oTabla = new tblDocEntrada();
                        oTabla.radicado = model.Radicado_Entrada;
                        oTabla.idRemitente = model.ID_Remitente;
                        oTabla.fechaEntrada = model.Fecha_Entrada;

                        db.tblDocEntrada.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("/DocEntrada/Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public ActionResult Editar(int Radicado_Entrada)
        {
            DocEntradaViewModel model = new DocEntradaViewModel();
            using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
            {
                var oTabla = db.tblDocEntrada.Find(Radicado_Entrada);
                oTabla.radicado = model.Radicado_Entrada;
                oTabla.fechaEntrada = model.Fecha_Entrada;
                oTabla.idRemitente = model.ID_Remitente;
                db.tblDocEntrada.Add(oTabla);
                db.SaveChanges();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Editar(DocEntradaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
                    {
                        var oTabla = db.tblDocEntrada.Find(model.Radicado_Entrada);
                        oTabla.radicado = model.Radicado_Entrada;
                        oTabla.fechaEntrada = model.Fecha_Entrada;
                        oTabla.idRemitente = model.ID_Remitente;
                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/DocEntrada/Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult Eliminar(int Radicado_Entrada)
        {
            DocEntradaViewModel model = new DocEntradaViewModel();
            using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
            {

                var oTabla = db.tblDocEntrada.Find(Radicado_Entrada);
                db.tblDocEntrada.Remove(oTabla);
                db.SaveChanges();

            }
            return Redirect("/DocEntrada/Index");
        }


    }
}