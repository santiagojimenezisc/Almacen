using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SJ_Almacen.Models;

namespace SJ_Almacen.Controllers
{
    public class containersController : Controller
    {
        private DataBase db = new DataBase();

        // GET: containers
        public ActionResult Index()
        {
            return View(db.container.ToList());
        }

        // GET: containers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            container container = db.container.Find(id);
            if (container == null)
            {
                return HttpNotFound();
            }
            return View(container);
        }

        // GET: containers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: containers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,price,exist")] container container)
        {
            if (ModelState.IsValid)
            {
                db.container.Add(container);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(container);
        }

        // GET: containers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            container container = db.container.Find(id);
            if (container == null)
            {
                return HttpNotFound();
            }
            return View(container);
        }

        // POST: containers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,price,exist")] container container)
        {
            if (ModelState.IsValid)
            {
                db.Entry(container).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(container);
        }

        // GET: containers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            container container = db.container.Find(id);
            if (container == null)
            {
                return HttpNotFound();
            }
            return View(container);
        }

        // POST: containers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            container container = db.container.Find(id);
            db.container.Remove(container);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Vender(string id_product,string producto_vendido)
        {
            DataBase db = new DataBase();
            int id_product1 = Convert.ToInt32(id_product);
            
            var query = db.container.SqlQuery("UPDATE container SET exist = exist + @producto_vendido WHERE ID = @id_product", producto_vendido, id_product);
            if (id_product != null )
            {
                return RedirectToAction("Vender", "containers");

            }
            else
            {

                return RedirectToAction("Vender", new { message = "No se ha encontrado dicho producto." });

            }

           
          
        }

        public ActionResult Buy(string id_product, string producto_comprado)
        {
            DataBase db = new DataBase();
            int id_product1 = Convert.ToInt32(id_product);

            var query = db.container.SqlQuery("UPDATE container SET exist = exist - @producto_comprado WHERE ID = @id_product", producto_comprado, id_product);
            if (id_product != null)
            {
                return RedirectToAction("Buy", "containers");

            }
            else
            {

                return RedirectToAction("Create", new { message = "No se ha encontrado dicho producto por tanto se redireccionara a crearlo." });

            }
        }
        
        
    }
}
