using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Glasfy06Proyecto.Models;

namespace Glasfy06Proyecto.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.proveedor.ToList());
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(proveedor proveedor)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())
                {

                    db.proveedor.Add(proveedor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }
        public ActionResult Edit(int id)
        {

            try
            {
                using (var db = new inventario2021Entities())
                {
                    proveedor findUser = db.proveedor.Where(a => a.id == id).FirstOrDefault();
                    return View(findUser);

                }

            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();


            }



        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(proveedor proveedorEdit)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventario2021Entities())
                {
                    proveedor user = db.proveedor.Find(proveedorEdit.id);

                    user.nombre = proveedorEdit.nombre;
                    user.direccion = proveedorEdit.direccion;
                    user.telefono = proveedorEdit.telefono;
                    user.nombre_contacto = proveedorEdit.nombre_contacto;


                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            using (var db = new inventario2021Entities())
            {
                proveedor user = db.proveedor.Find(id);
                return View(user);
            }
        }
        public ActionResult Delete(int id)
        {
            using (var db = new inventario2021Entities())
            {
                var proveedor = db.proveedor.Find(id);
                db.proveedor.Remove(proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        


    }
}