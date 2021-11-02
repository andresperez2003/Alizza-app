

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Documento.Models.ViewModels;
using Logeo.Data;

namespace Documento.Controllers
{
    public class CiudadDptoController : Controller
    {
        public ActionResult Index()
        {
            List<ListCiudadDpto> lst;
            using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
            {
                lst = (from d in db.tblCiudadDpto
                       select new ListCiudadDpto
                       {
                           IDCiudad = d.idCiudad,
                           Ciudad = d.ciudad,
                           Departamento = d.departamento
                       }).ToList();
            }
            return View(lst);


        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(CiudadDptoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
                    {
                        var oTabla = new tblCiudadDpto();
                        oTabla.idCiudad = model.IDCiudad;
                        oTabla.ciudad = model.Ciudad;
                        oTabla.departamento = model.Departamento;
                        db.tblCiudadDpto.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("/CiudadDpto/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public ActionResult Editar(int IDCiudad)
        {
            CiudadDptoViewModel model = new CiudadDptoViewModel();
            using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
            {
                var oTabla = db.tblCiudadDpto.Find(IDCiudad);
                oTabla.idCiudad = model.IDCiudad;
                oTabla.ciudad = model.Ciudad;
                oTabla.departamento = model.Departamento;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Editar(CiudadDptoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
                    {
                        var oTabla = db.tblCiudadDpto.Find(model.IDCiudad);
                        oTabla.idCiudad = model.IDCiudad;
                        oTabla.ciudad = model.Ciudad;
                        oTabla.departamento = model.Departamento;
                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/CiudadDpto/Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult Eliminar(int IDCiudad)
        {
            CiudadDptoViewModel model = new CiudadDptoViewModel();
            using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
            {

                var oTabla = db.tblCiudadDpto.Find(IDCiudad);
                db.tblCiudadDpto.Remove(oTabla);
                db.SaveChanges();

            }
            return Redirect("/CiudadDpto/Index");
        }
    }
}