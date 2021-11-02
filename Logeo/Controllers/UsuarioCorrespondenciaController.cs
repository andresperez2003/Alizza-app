
using Documento.Models.ViewModels;
using Logeo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Documento.Controllers
{
    public class UsuarioCorrespondenciaController : Controller
    {
        public ActionResult Index()
        {
            List<ListUsuarioCorrespondencia> lst;
            using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
            {
                lst = (from d in db.tblUsuarioCorrespondencia
                       select new ListUsuarioCorrespondencia
                       {
                           ID = d.id,
                           NombreRazonSocial = d.nombreRazonSocial,
                           Direccion = d.direccion,
                           IDCiudad = d.idCiudad
                       }).ToList();
            }
            return View(lst);


        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(UsuarioCorrespondenciaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
                    {
                        var oTabla = new tblUsuarioCorrespondencia();
                        oTabla.id = model.ID;
                        oTabla.nombreRazonSocial = model.NombreRazonSocial;
                        oTabla.direccion = model.Direccion;
                        oTabla.idCiudad = model.IDCiudad;

                        db.tblUsuarioCorrespondencia.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("/UsuarioCorrespondencia/Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public ActionResult Editar(int ID)
        {
            UsuarioCorrespondenciaViewModel model = new UsuarioCorrespondenciaViewModel();
            using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
            {
                var oTabla = db.tblUsuarioCorrespondencia.Find(ID);
                oTabla.id = model.ID;
                oTabla.nombreRazonSocial = model.NombreRazonSocial;
                oTabla.direccion = model.Direccion;
                oTabla.idCiudad = model.IDCiudad;
                db.tblUsuarioCorrespondencia.Add(oTabla);
                db.SaveChanges();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Editar(UsuarioCorrespondenciaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
                    {
                        var oTabla = db.tblUsuarioCorrespondencia.Find(model.ID);
                        oTabla.id = model.ID;
                        oTabla.nombreRazonSocial = model.NombreRazonSocial;
                        oTabla.direccion = model.Direccion;
                        oTabla.idCiudad = model.IDCiudad;
                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("/UsuarioCorrespondencia/Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpGet]
        public ActionResult Eliminar(int ID)
        {
            DocEntradaViewModel model = new DocEntradaViewModel();
            using (dbCorrespondenciaEntities db = new dbCorrespondenciaEntities())
            {

                var oTabla = db.tblUsuarioCorrespondencia.Find(ID);
                db.tblUsuarioCorrespondencia.Remove(oTabla);
                db.SaveChanges();

            }
            return Redirect("/UsuarioCorrespondencia/Index");
        }
    }
}