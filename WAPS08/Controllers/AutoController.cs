using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WAPS08.Models;
using WAPS08.Models.ViewModels;

namespace WAPS08.Controllers
{
    public class AutoController : Controller
    {
        // GET: Auto
        // ----------------------------------------------------------------------
        // Consulta Los autos que tienen estatus 1
        // ----------------------------------------------------------------------
        public ActionResult Query()
        {
            List<AutoTableViewModel> lst = null;   

            using (DBMVCSCEntities db = new DBMVCSCEntities())  
            {
                lst = (from d in db.AUTOS              // SELECT * FROM AUTOS ORDER BY IDAUTO ASC
                       where d.miEstatus == 1
                       orderby d.IDauto

                       select new AutoTableViewModel        
                       {                                   
                           _Idauto = d.IDauto,
                           _Marca = d.Marca,
                           _Modelo = d.Modelo,
                           _Anio = d.Anio,
                           _Imagen = d.ImgRuta
                           //_Direccion = d.Direccion,
                           //_TipoVehiculo = d.TipoVehiculo,
                           //_Color = d.Color,
                           //_Precio = (float)d.Precio
                         
                       }).ToList();
            }

            return View();         
        }

        // ----------------------------------------------------------------------
        // Abre la pagina de autos
        // ----------------------------------------------------------------------
        [HttpGet]
        public ActionResult AddAuto()
        {
            return View();
        }

        // ----------------------------------------------------------------------
        // Agrega un Auto
        // ----------------------------------------------------------------------
        [HttpPost]
        public ActionResult AddAuto(AddAutoViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string filename = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            string extension = Path.GetExtension(model.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            model.Imagen = "~/Image/"  + filename;
            filename = Path.Combine(Server.MapPath("~/Image/") + filename );
            model.ImageFile.SaveAs(filename);
            using (var db = new DBMVCSCEntities())
            {
                AUTO oUser = new AUTO();
                oUser.miEstatus = 1;
                oUser.Marca = model.Marca;
                oUser.Modelo = model.Modelo;
                oUser.Anio = model.Anio;
                oUser.ImgRuta = model.Imagen;
                oUser.Direccion = model.Direccion;
                oUser.TipoVehiculo = model.TipoVehiculo;
                oUser.Color = model.Color;
                oUser.Precio = (float)model.Precio;
                


                db.AUTOS.Add(oUser);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Auto/query"));
        }

        // ----------------------------------------------------------------------
        // Edita un usuario
        // ----------------------------------------------------------------------
        [HttpGet]
        public ActionResult EditAuto(int Id)
        {
            EditAutoViewModels model = new EditAutoViewModels();
            using (var db = new DBMVCSCEntities())
            {
                var oUser = db.AUTOS.Find(Id);  // SELECT * FROM USER WHERE ID = 4
                model.Marca = oUser.Marca;
                model.Modelo = oUser.Modelo;
                model.Anio = oUser.Anio;
                model.Imagen = oUser.ImgRuta;
                model.Direccion = oUser.Direccion;
                model.TipoVehiculo = oUser.TipoVehiculo;
                model.Color = oUser.Color;
                model.Precio = (float)oUser.Precio;
            }

            return View(model);
        }

        // ----------------------------------------------------------------------
        // Realiza un Update al usuario
        // ----------------------------------------------------------------------
        [HttpPost]
        public ActionResult EditAuto(EditAutoViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new DBMVCSCEntities())
            {
                var oUser = db.AUTOS.Find(model.IdAuto);
                oUser.Marca = model.Marca;
                oUser.Modelo = model.Modelo;
                oUser.ImgRuta = model.Imagen;
                oUser.Anio = model.Anio;
                oUser.Direccion = model.Direccion;
                oUser.TipoVehiculo = model.TipoVehiculo;
                oUser.Color = model.Color;
                oUser.Precio = (float)model.Precio; 

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Auto/query"));
        }

        // ----------------------------------------------------------------------
        // Borrar o Marcar un usuario
        // ----------------------------------------------------------------------
        [HttpPost]
        public ActionResult DeleteAuto(int Id)
        {
            using (var db = new DBMVCSCEntities())
            {
                var oUser = db.AUTOS.Find(Id);
                oUser.miEstatus = 3;

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return Content("1");
            }

            //return null;
        }
    }
}