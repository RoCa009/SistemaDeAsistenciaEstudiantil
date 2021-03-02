using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CentroEscolar.EntidadesDeNegocio;
using CentroEscolar.LogicaDeNegocio;

namespace CentroEscolar.InterfazMVC.Controllers
{
    public class SeccionController : Controller
    {

        SeccionBL seccion = new SeccionBL();
        // GET: Seccion
        public ActionResult Index()
        {
            return View();
        }
        // Obtener 
        public JsonResult Obtener()
        {
            return Json(seccion.Obtener(), JsonRequestBehavior.AllowGet);
        }
        // BuscarPorId
        public JsonResult BuscarPorId(int pId)
        {
            return Json(seccion.BuscarPorId(pId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Agregar(Seccion pSeccion)
        {
            return Json(seccion.Agregar(pSeccion), JsonRequestBehavior.AllowGet);
        }

        // Modificar
        [HttpPost]
        public JsonResult Modificar(Seccion pSeccion)
        {
            return Json(seccion.Modificar(pSeccion), JsonRequestBehavior.AllowGet);
        }

        // Eliminar
        [HttpPost]
        public JsonResult Eliminar(int pId)
        {
            return Json(seccion.Eliminar(pId));
        }

    }
}