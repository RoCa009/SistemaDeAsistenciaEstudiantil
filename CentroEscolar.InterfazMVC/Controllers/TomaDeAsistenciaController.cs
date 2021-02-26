using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CentroEscolar.EntidadesDeNegocio;
using CentroEscolar.LogicaDeNegocio;

namespace CentroEscolar.InterfazMVC.Controllers
{
    public class TomaDeAsistenciaController : Controller
    {
        TomaDeAsistenciaBL tomadeasistencia = new TomaDeAsistenciaBL();

        // GET: TomaDeAsistencia
        public ActionResult Index()
        {
            return View();
        }

        // Obtener 
        public JsonResult Obtener()
        {
            return Json(tomadeasistencia.Obtener(), JsonRequestBehavior.AllowGet);
        }
    }
}