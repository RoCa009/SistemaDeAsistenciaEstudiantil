using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CentroEscolar.EntidadesDeNegocio;
using CentroEscolar.LogicaDeNegocio;

namespace CentroEscolar.InterfazMVC.Controllers
{
    public class HorarioController : Controller
    {
        HorarioBL horario = new HorarioBL();

        // Mostrar
        public ActionResult Index()
        {
            return View();
        }

        // Obtener 
        public JsonResult Obtener()
        {
            return Json(horario.Obtener(), JsonRequestBehavior.AllowGet);
        }

        // BuscarPorId
        public JsonResult BuscarPorId(int pId)
        {
            return Json(horario.BuscarPorId(pId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Agregar(Horario pHorario)
        {
            return Json(horario.Agregar(pHorario), JsonRequestBehavior.AllowGet);
        }

        // Modificar
        [HttpPost]
        public JsonResult Modificar(Horario pHorario)
        {
            return Json(horario.Modificar(pHorario), JsonRequestBehavior.AllowGet);
        }

        // Eliminar
        [HttpPost]
        public JsonResult Eliminar(int pId)
        {
            return Json(horario.Eliminar(pId));
        }
    }
}