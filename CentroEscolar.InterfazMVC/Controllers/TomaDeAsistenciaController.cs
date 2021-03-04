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

        // BuscarPorId
        public JsonResult BuscarPorId(int pId)
        {
            return Json(tomadeasistencia.BuscarPorId(pId), JsonRequestBehavior.AllowGet);
        }

        // BuscarPorId
        public JsonResult BuscarPorIdAlumno(int pId)
        {
            return Json(tomadeasistencia.BuscarPorIdAlumno(pId), JsonRequestBehavior.AllowGet);
        }

        // Agregar
        [HttpPost]
        public JsonResult Agregar(TomaDeAsistencia pTomaDeAsistencia)
        {
            return Json(tomadeasistencia.Agregar(pTomaDeAsistencia), JsonRequestBehavior.AllowGet);
        }

        // Modificar
        [HttpPost]
        public JsonResult Modificar(TomaDeAsistencia pTomaDeAsistencia)
        {
            return Json(tomadeasistencia.Modificar(pTomaDeAsistencia), JsonRequestBehavior.AllowGet);
        }

        // Eliminar
        [HttpPost]
        public JsonResult Eliminar(int pId)
        {
            return Json(tomadeasistencia.Eliminar(pId));
        }
    }
}