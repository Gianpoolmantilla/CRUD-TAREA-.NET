using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using apnetTareasMVC_CRUD.Models;

namespace apnetTareasMVC_CRUD.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(USUARIOS userModel)
        {
            using (BaseTareasSEntities con = new BaseTareasSEntities())
            {
                var userDetails = con.USUARIOS.Where(x => x.USERID == userModel.USERID && x.PASSWORD == userModel.PASSWORD).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.loginErrorMessage = "Incorrecto usuario o contraseña";
                    return View("index", userModel);
                }
                else
                {
                    Session["NOMBRE"] = userDetails.NOMBRE;
                    Session["ID"] = userDetails.ID;
                    return RedirectToAction("index", "Home");
                }

            }
            //   return View();
        }

        public ActionResult LogOut()
        {
            int id = (int)Session["ID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");

        }

    }
}