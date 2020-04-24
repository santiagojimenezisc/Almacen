using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SJ_Almacen.Models;
namespace SJ_Almacen.Controllers
{
    public class PruebaDatabaseController : Controller
    {
        // GET: PruebaDatabase
        public ActionResult Index()
        {


            //DataBase

            DataBase db = new DataBase();
            var listusuarios = db.login.ToList();

            return new JsonResult { 
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = listusuarios
            };
        }
    }
}