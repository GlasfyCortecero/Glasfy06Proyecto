using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Glasfy06Proyecto.Models;

namespace Glasfy06Proyecto.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.usuario.ToList());
            }

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(usuario usuario)
        {
            if (!ModelState.IsValid)
                return View();

            try {
                using (var db = new inventario2021Entities())
                {
                    usuario.password = UsuarioController.HashSHA1(usuario.password);
                    db.usuario.Add(usuario);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            } catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();

            }
        } 

        public static string HashSHA1(string value)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        
           
         
        
        
    }
}