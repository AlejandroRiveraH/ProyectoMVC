using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Herramienta_Vista()
        {
            ViewBag.Message = "Esta es la página de herramientas.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Esta es la descripción de la materia.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Su página de contacto.";

            return View();
        }
    }
}