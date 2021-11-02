
using Documento.Models.ViewModels;
using Logeo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Documento.Controllers
{
    public class DocSalidaController : Controller
    {
        // GET: DocSalida
        public ActionResult Index()
        {
            List<ListDocSalida> lst;
            using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
            {
                lst = (from d in db.tblDocSalida
                       select new ListDocSalida
                       {
                           Radicado_Salida = d.radicado,
                           IDDependencia = d.idDependencia,
                           IDDestinatario = d.idDestinatario,
                           FechaSalida = d.fechaSalida
                       }).ToList();
            }
            return View(lst);


        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(DocSalidaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
                    {
                        var oTabla = new tblDocSalida();
                        oTabla.radicado = model.Radicado_Salida;
                        oTabla.idDependencia = model.ID_Dependencia;
                        oTabla.idDestinatario = model.ID_Destinatario;
                        oTabla.fechaSalida = model.Fecha_Salida;

                        db.tblDocSalida.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("/DocSalida/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public ActionResult Editar(int Radicado1)
        {
            DocSalidaViewModel model = new DocSalidaViewModel();
            using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
            {
                var oTabla = db.tblDocSalida.Find(Radicado1);
                model.ID_Destinatario = oTabla.idDestinatario;
                model.ID_Dependencia = oTabla.idDependencia;
                model.Fecha_Salida = oTabla.fechaSalida;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Editar(DocSalidaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
                    {
                        var oTabla = db.tblDocSalida.Find(model.Radicado_Salida);
                        oTabla.idDestinatario = model.ID_Destinatario;
                        oTabla.fechaSalida = model.Fecha_Salida;
                        oTabla.radicado = model.Radicado_Salida;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/DocSalida/Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult Eliminar(int Radicado1)
        {
            DocSalidaViewModel model = new DocSalidaViewModel();
            using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
            {

                var oTabla = db.tblDocSalida.Find(Radicado1);
                db.tblDocSalida.Remove(oTabla);
                db.SaveChanges();

            }
            return Redirect("/DocSalida/Index");
        }


    }

}