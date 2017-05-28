using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoHackatonIncredibleHihgSpeedTeam.Repository;

namespace ProjetoHackatonIncredibleHihgSpeedTeam.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Login()
		{
			return View();
		}
        [HttpPost]
        public ActionResult Logar(String Nome, String Pass)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                try
                {
                    var log = conexao.TB_USER.Single(x => x.NM_NOME == Nome && x.DS_SENHA == Pass);
                    TempData["User"] = Nome;
                    return RedirectToAction("Index", "User");
                }
                catch
                {

                }
            }
            return RedirectToAction("Login");
        }
    }
}