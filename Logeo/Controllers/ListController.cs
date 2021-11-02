
using Documento.Models.ViewModels;
using Logeo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Documento.Controllers
{
    public class ListController : Controller
    {
        // GET: List
        public ActionResult Index()
        {
            List<ListTablaViewModel> lst;
            using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
            {
                lst = (from d in db.tblDocumento
                       select new ListTablaViewModel
                       {
                           Radicado = d.radicado,
                           Categoria = d.categoria,
                           Tipo = d.tipo


                       }).ToList();


                return View(lst);
            }

        }

        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
                    {
                        var oTabla = new tblDocumento();
                        oTabla.tipo = model.Tipo;
                        oTabla.radicado = model.Radicado;
                        oTabla.categoria = model.Categoria;

                        db.tblDocumento.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("/list/Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public ActionResult Editar(int Radicado)
        {
            TablaViewModel model = new TablaViewModel();
            using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
            {
                var oTabla = db.tblDocumento.Find(Radicado);
                model.Radicado = oTabla.radicado;
                model.Categoria = oTabla.categoria;
                model.Tipo = oTabla.tipo;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Editar(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
                    {
                        var oTabla = db.tblDocumento.Find(model.Radicado);
                        oTabla.tipo = model.Tipo;
                        oTabla.radicado = model.Radicado;
                        oTabla.categoria = model.Categoria;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/list/Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult Eliminar(int Radicado)
        {
            TablaViewModel model = new TablaViewModel();
            using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
            {

                var oTabla = db.tblDocumento.Find(Radicado);
                db.tblDocumento.Remove(oTabla);
                db.SaveChanges();

            }
            return Redirect("/list/Index");
        }

    }

}
