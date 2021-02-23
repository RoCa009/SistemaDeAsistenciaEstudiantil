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

        // Obtener: Horario
        public ActionResult Index()
        {
            return View();
        }


    }
}