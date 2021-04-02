using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using apnetTareasMVC_CRUD.Models;

namespace apnetTareasMVC_CRUD.Controllers
{
    public class TareaPorEstadoController : Controller
    {
        // GET: TareaPorEstado
        public ActionResult Index()
        {
            BaseTareasSEntities bd = new BaseTareasSEntities();

            List<TAREAS> tarea = bd.TAREAS.ToList();
            List<PRIORIDAD> Dsprioridad = bd.PRIORIDAD.ToList();
            List<TIPO> Dstipo = bd.TIPO.ToList();


            var reporte = from tr in tarea
                          join ti in Dstipo on tr.TIPO equals ti.ID into table1
                          from ti in table1.DefaultIfEmpty()
                          join pri in Dsprioridad on tr.PRIORIDAD equals pri.ID into table2
                          from pri in table2.DefaultIfEmpty()
                          select new TareaPorEstado { DSTIPO = ti, TAREA = tr, DSPRIORIDAD = pri };



            return View(reporte);
        }
    }
}