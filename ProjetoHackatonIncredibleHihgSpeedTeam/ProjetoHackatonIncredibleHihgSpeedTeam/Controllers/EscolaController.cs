using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoHackatonIncredibleHihgSpeedTeam.Controllers
{
    public class EscolaController : Controller
    {
        // GET: Escola
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista()
        {
            //Listar todos as Empresas
            return View();
        }

        public ActionResult Create()
        {
            //ViewBag.ID_Carreira = new SelectList(
            return View();
        }

        public ActionResult Delete()
        {
            //redirect
            return View();
        }
    }
}