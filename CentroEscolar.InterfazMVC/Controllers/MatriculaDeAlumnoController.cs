using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CentroEscolar.EntidadesDeNegocio;
using CentroEscolar.LogicaDeNegocio;

namespace CentroEscolar.InterfazMVC.Controllers
{
    public class MatriculaDeAlumnoController : Controller
    {
        MatriculaDeAlumnoBL matriculadealumno = new MatriculaDeAlumnoBL();

        // Mostrar
        public ActionResult Index()
        {
            return View();
        }

        // Obtener 
        public JsonResult Obtener()
        {
            return Json(matriculadealumno.Obtener(), JsonRequestBehavior.AllowGet);
        }

        // BuscarPorId
        public JsonResult BuscarPorId(int pId)
        {
            return Json(matriculadealumno.BuscarPorId(pId), JsonRequestBehavior.AllowGet);
        }

        // Agregar
        [HttpPost]
        public JsonResult Agregar(MatriculaDeAlumno pMatriculaDeAlumno)
        {
            return Json(matriculadealumno.Agregar(pMatriculaDeAlumno), JsonRequestBehavior.AllowGet);
        }

        // Modificar
        [HttpPost]
        public JsonResult Modificar(MatriculaDeAlumno pMatriculaDeAlumno)
        {
            return Json(matriculadealumno.Modificar(pMatriculaDeAlumno), JsonRequestBehavior.AllowGet);
        }

        // Eliminar
        [HttpPost]
        public JsonResult Eliminar(int pId)
        {
            return Json(matriculadealumno.Eliminar(pId));
        }
    }
}