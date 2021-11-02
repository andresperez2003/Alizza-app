
using Documento.Models.ViewModels;
using Logeo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Documento.Controllers
{
    public class DependenciaController : Controller
    {
        public ActionResult Index()
        {
            List<ListDependencia> lst;
            using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
            {
                lst = (from d in db.tblDependencia
                       select new ListDependencia
                       {
                           IDDependencia = d.idDependencia,
                           Dependencia = d.dependencia,
                           Nivel = d.nivel

                       }).ToList();
            }
            return View(lst);


        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(DependenciaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
                    {
                        var oTabla = new tblDependencia();
                        oTabla.idDependencia = model.IDDependencia;
                        oTabla.nivel = model.Nivel;
                        oTabla.dependencia = model.Dependencia;
                        db.tblDependencia.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("/Dependencia/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public ActionResult Editar(int IDDependencia)
        {
            DependenciaViewModel model = new DependenciaViewModel();
            using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
            {
                var oTabla = db.tblDependencia.Find(IDDependencia);
                oTabla.idDependencia = model.IDDependencia;
                oTabla.nivel = model.Nivel;
                oTabla.dependencia = model.Dependencia;
                db.tblDependencia.Add(oTabla);
                db.SaveChanges();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Editar(DependenciaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
                    {
                        var oTabla = db.tblDependencia.Find(model.IDDependencia);
                        oTabla.idDependencia = model.IDDependencia;
                        oTabla.nivel = model.Nivel;
                        oTabla.dependencia = model.Dependencia;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/Dependencia/Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult Eliminar(int IDDependencia)
        {
            DependenciaViewModel model = new DependenciaViewModel();
            using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
            {

                var oTabla = db.tblDependencia.Find(IDDependencia);
                db.tblDependencia.Remove(oTabla);
                db.SaveChanges();

            }
            return Redirect("/Depedencia/Index");
        }
    }
}