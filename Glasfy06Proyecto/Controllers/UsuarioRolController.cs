using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Glasfy06Proyecto.Models;


namespace Glasfy06Proyecto.Controllers
{
    public class UsuarioRolController : Controller
    {
        // GET: UsuarioRol
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.usuariorol.ToList());
            }
        }
        public static string NombreUsuario(int idUsuario)
        {
            using (var db = new inventario2021Entities())
            {
                return db.usuario.Find(idUsuario).nombre;
            }
        }
        public ActionResult ListarUsuarios()
        {
            using (var db = new inventario2021Entities())

            {
                return PartialView(db.usuario.ToList());

            }
        }
        public static string NombreRol(int idRol)
        {
            using (var db = new inventario2021Entities())
            {
                return db.roles.Find(idRol).descripcion;
            }
        }
        public ActionResult ListarRoles()
        {
            using (var db = new inventario2021Entities())

            {
                return PartialView(db.roles.ToList());

            }
        }
        public ActionResult Create()

        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(usuariorol usuarioRol)

        {

            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())

                {
                    db.usuariorol.Add(usuarioRol);
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
                usuariorol usuariorolDetalle = db.usuariorol.Where(a => a.id == id).FirstOrDefault();
                return View(usuariorolDetalle);
            }
        }
        public ActionResult Delete(int id)
        {
            using (var db = new inventario2021Entities())
            {
                var usuariorolDelete = db.usuariorol.Find(id);
                db.usuariorol.Remove(usuariorolDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    usuariorol finduser = db.usuariorol.Where(a => a.id == id).FirstOrDefault();
                    return View(finduser);
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
        public ActionResult Edit(usuariorol usuarioRolEdit)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    usuariorol usuarioRol = db.usuariorol.Find(usuarioRolEdit.id);
                    usuarioRol.idUsuario = usuarioRolEdit.idUsuario;
                    usuarioRol.idRol = usuarioRolEdit.idRol;


                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }

        }



    }
}

