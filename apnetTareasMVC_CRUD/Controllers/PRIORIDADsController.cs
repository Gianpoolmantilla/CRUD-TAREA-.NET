using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using apnetTareasMVC_CRUD.Models;

namespace apnetTareasMVC_CRUD.Controllers
{
    public class PRIORIDADsController : Controller
    {
        private BaseTareasSEntities db = new BaseTareasSEntities();

        // GET: PRIORIDADs
        public ActionResult Index()
        {
            return View(db.PRIORIDAD.ToList());
        }

        // GET: PRIORIDADs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRIORIDAD pRIORIDAD = db.PRIORIDAD.Find(id);
            if (pRIORIDAD == null)
            {
                return HttpNotFound();
            }
            return View(pRIORIDAD);
        }

        // GET: PRIORIDADs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRIORIDADs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DESCRIPCION")] PRIORIDAD pRIORIDAD)
        {
            if (ModelState.IsValid)
            {
                db.PRIORIDAD.Add(pRIORIDAD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pRIORIDAD);
        }

        // GET: PRIORIDADs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRIORIDAD pRIORIDAD = db.PRIORIDAD.Find(id);
            if (pRIORIDAD == null)
            {
                return HttpNotFound();
            }
            return View(pRIORIDAD);
        }

        // POST: PRIORIDADs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DESCRIPCION")] PRIORIDAD pRIORIDAD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRIORIDAD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pRIORIDAD);
        }

        // GET: PRIORIDADs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRIORIDAD pRIORIDAD = db.PRIORIDAD.Find(id);
            if (pRIORIDAD == null)
            {
                return HttpNotFound();
            }
            return View(pRIORIDAD);
        }

        // POST: PRIORIDADs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRIORIDAD pRIORIDAD = db.PRIORIDAD.Find(id);
            db.PRIORIDAD.Remove(pRIORIDAD);
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
    }
}
