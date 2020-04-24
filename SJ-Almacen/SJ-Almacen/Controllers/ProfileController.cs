using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SJ_Almacen.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        // GET: Profile
        
        public ActionResult Index()
        {
            return View();
        }
    }
}