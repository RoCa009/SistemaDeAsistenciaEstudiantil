using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CentroEscolar.EntidadesDeNegocio;
using CentroEscolar.LogicaDeNegocio;

namespace CentroEscolar.InterfazMVC.Controllers
{
    public class ProfesorController : Controller
    {
        ProfesorBL profesor = new ProfesorBL();

        // Mostrar
        public ActionResult Index()
        {
            return View();
        }

        // Obtener 
        public JsonResult Obtener()
        {
            return Json(profesor.Obtener(), JsonRequestBehavior.AllowGet);
        }

        // BuscarPorId
        public JsonResult BuscarPorId(int pId)
        {
            return Json(profesor.BuscarPorId(pId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Agregar(Profesor pProfesor)
        {
            return Json(profesor.Agregar(pProfesor), JsonRequestBehavior.AllowGet);
        }

        // Modificar
        [HttpPost]
        public JsonResult Modificar(Profesor pProfesor)
        {
            return Json(profesor.Modificar(pProfesor), JsonRequestBehavior.AllowGet);
        }

        // Eliminar
        [HttpPost]
        public JsonResult Eliminar(int pId)
        {
            return Json(profesor.Eliminar(pId));
        }
    }
}