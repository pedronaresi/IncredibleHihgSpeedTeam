using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoHackatonIncredibleHihgSpeedTeam.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Lista_Empresas()
        {
            //verificar qualificacoes do usuario e mostrar empresas de 75% pra cima
            return View();
        }

        public ActionResult ListaEscolas()
        {
            //Listar escolas q fornecem os cursos nescessarios
            return View();
        }

        public ActionResult Perfil()
        {

            return View();
        }

        public ActionResult Perfil()
        {
            return View();
        }
    }
}
