using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apnetTareasMVC_CRUD.Models
{
    public class TareaPorEstado
    {
        public PRIORIDAD DSPRIORIDAD { get; set; }
        public TAREAS TAREA { get; set; }
        public TIPO DSTIPO { get; set; }

    }
}