using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CentroEscolar.EntidadesDeNegocio;
using CentroEscolar.LogicaDeNegocio;

namespace CentroEscolar.InterfazMVC.Controllers
{
    public class AulaController : Controller
    {
        AulaBL aula = new AulaBL();

        // Accion que muestra la vista
        public ActionResult Index()
        {
            return View();
        }
        // Obtener 
        public JsonResult Obtener()
        {
            return Json(aula.Obtener(), JsonRequestBehavior.AllowGet);
        }
        // BuscarPorId
        public JsonResult BuscarPorId(int pId)
        {
            return Json(aula.BuscarPorId(pId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Agregar(Aula pAula)
        {
            return Json(aula.Agregar(pAula), JsonRequestBehavior.AllowGet);
        }

        // Modificar
        [HttpPost]
        public JsonResult Modificar(Aula pAula)
        {
            return Json(aula.Modificar(pAula), JsonRequestBehavior.AllowGet);
        }

        // Eliminar
        [HttpPost]
        public JsonResult Eliminar(int pId)
        {
            return Json(aula.Eliminar(pId));
        }

    }
}