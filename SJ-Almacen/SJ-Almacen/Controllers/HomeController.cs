using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SJ_Almacen.Models;

namespace SJ_Almacen.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }
        [HttpPost]
        public ActionResult About(string email)
        {
            ViewBag.Message = "Your application description page.";

            //Modelo MVC 

            //Modelo = usuario

            List<Usuario> usuarios = new List<Usuario>()
            {
                new Usuario { Email = email, Name = "Santiago"},
                new Usuario {Email = "santiagojimenezisc@gmail.com", Name = "Test"}
            };


            return View(usuarios);
        }
        [HttpPost]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {

            if(!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {

                DataBase db = new DataBase();

                var user = db.login.FirstOrDefault(e => e.user == email && e.password == password);
                //si usuario es difernete de null
                if (user != null)
                {

                    FormsAuthentication.SetAuthCookie(user.user, true);
                    return RedirectToAction("Index", "Profile");
                   
                }
                else
                {

                    return RedirectToAction("Index", new { message  = "Correo o contraseña incorrecta."});

                }
            }
            else
            {
                return RedirectToAction("Index", new { message = "Llena los campos para poder inicar sesion" });
                
            }

        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }

    public class Usuario
    {
        public string Email { get; set; }
        public string Name { get; set; }
        //Enaviar correo 
        public void SendEmail()
        {

        }
    }
}