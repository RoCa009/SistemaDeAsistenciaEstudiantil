using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CentroEscolar.EntidadesDeNegocio;
using CentroEscolar.LogicaDeNegocio;

namespace CentroEscolar.InterfazMVC.Controllers
{
    public class AdministradorController : Controller
    {
        AdministradorBL administrador = new AdministradorBL();

        // Mostrar
        public ActionResult Index()
        {
            return View();
        }

        // Obtener 
        public JsonResult Obtener()
        {
            return Json(administrador.Obtener(), JsonRequestBehavior.AllowGet);
        }
    }
}