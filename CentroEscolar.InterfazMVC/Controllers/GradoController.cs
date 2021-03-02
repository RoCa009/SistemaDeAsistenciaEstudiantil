using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CentroEscolar.EntidadesDeNegocio;
using CentroEscolar.LogicaDeNegocio;

namespace CentroEscolar.InterfazMVC.Controllers
{
    public class GradoController : Controller
    {
        GradoBL grado = new GradoBL();
        // GET: Grado
        public ActionResult Index()
        {
            return View();
        }
        // Obtener 
        public JsonResult Obtener()
        {
            return Json(grado.Obtener(), JsonRequestBehavior.AllowGet);
        }
        // BuscarPorId
        public JsonResult BuscarPorId(int pId)
        {
            return Json(grado.BuscarPorId(pId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Agregar(Grado pGrado)
        {
            return Json(grado.Agregar(pGrado), JsonRequestBehavior.AllowGet);
        }

        // Modificar
        [HttpPost]
        public JsonResult Modificar(Grado pGrado)
        {
            return Json(grado.Modificar(pGrado), JsonRequestBehavior.AllowGet);
        }

        // Eliminar
        [HttpPost]
        public JsonResult Eliminar(int pId)
        {
            return Json(grado.Eliminar(pId));
        }

    }
}