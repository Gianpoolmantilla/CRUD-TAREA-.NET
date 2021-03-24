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
    public class TAREASController : Controller
    {
        public BaseTareasSEntities db = new BaseTareasSEntities();

        // GET: TAREAS
        public ActionResult Index()
        {
            //var desTipo = db.TIPO.Join(db.TAREAS, tipo => tipo.ID,
            //    tarea => tarea.TIPO, (tipo, tarea) => new { tipo, tarea }).FirstOrDefault( x=> x.tipo.ID== 1);
            //TAREAS TAREAS = new TAREAS();
            //List<TAREAS> ListItem = db.TAREAS.ToList(); 
            // return View(ListItem);

            // var descripcionTipo = db.TIPO.Select(x => new { x.DESCRIPCION }).FirstOrDefault();

            // var descripcionTipo = db.TIPO.Where(x => x.ID == 1).Include(x => x.DESCRIPCION).FirstOrDefault();
           
            //var descripcionTipo = db.TIPO.Where(x => x.ID == 1)
            //    .Select(x => new { x.DESCRIPCION }).FirstOrDefault();


            return View(db.TAREAS.ToList());
        }

        public ActionResult TareasPorEstado()
        {
            //var descripcionTipo = db.TIPO.Select(x => new { x.DESCRIPCION }).FirstOrDefault();
            //List<TAREAS> ListItem = new List<TAREAS>();
            //TAREAS tr = db.TAREAS.Find();

           


            //var descripcionTipo = db.TIPO.Where(x => x.ID == 2)
            //  .Select(x => new { x.DESCRIPCION }).First();

           
            //    tr.ID = item.ID;
            //    tr.DESCRIPCION = item.DESCRIPCION.ToList();
            //    tr.TIPO = 2;
            //    tr.OBSERVACION = item.OBSERVACION;
            //    tr.PRIORIDAD = 1;
            //    ListItem.Add(tr);          



            return View(db.TAREAS.ToList());
        }


        // GET: TAREAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAREAS tAREAS = db.TAREAS.Find(id);
            if (tAREAS == null)
            {
                return HttpNotFound();
            }
            return View(tAREAS);
        }

        // GET: TAREAS/Create
        public ActionResult Create(int id = 0)
        {
            TAREAS Coleccion = new TAREAS();
            Coleccion.ColeccionDeTipos = db.TIPO.ToList();
            Coleccion.coleccionDePrioridad = db.PRIORIDAD.ToList();

            return View(Coleccion);
        }

        // POST: TAREAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DESCRIPCION,TIPO,OBSERVACION,PRIORIDAD")] TAREAS tAREAS)
        {
            if (ModelState.IsValid)
            {
                db.TAREAS.Add(tAREAS);
                db.SaveChanges();
                return RedirectToAction("Create");
            }


            return View(tAREAS);
        }

        // GET: TAREAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAREAS tAREAS = db.TAREAS.Find(id);
            if (tAREAS == null)
            {
                return HttpNotFound();
            }
            return View(tAREAS);
        }

        // POST: TAREAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DESCRIPCION,TIPO,OBSERVACION,PRIORIDAD")] TAREAS tAREAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAREAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tAREAS);
        }

        // GET: TAREAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAREAS tAREAS = db.TAREAS.Find(id);
            if (tAREAS == null)
            {
                return HttpNotFound();
            }
            return View(tAREAS);
        }

        // POST: TAREAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TAREAS tAREAS = db.TAREAS.Find(id);
            db.TAREAS.Remove(tAREAS);
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
