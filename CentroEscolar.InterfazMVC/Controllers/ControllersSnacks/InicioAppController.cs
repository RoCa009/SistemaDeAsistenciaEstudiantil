using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentroEscolar.InterfazMVC.Controllers.ControllersSnacks
{
    public class InicioAppController : Controller
    {
        // GET: InicioApp
        public ActionResult Index()
        {
            return View();
        }
    }
}