using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< HEAD
=======
using ProjetoHackatonIncredibleHihgSpeedTeam.Repository;
using ProjetoHackatonIncredibleHihgSpeedTeam.Models;
>>>>>>> 4967de737a9eac122a8744372d316030fca1fb31

namespace ProjetoHackatonIncredibleHihgSpeedTeam.Controllers
{
    public class CarreiraController : Controller
    {
        // GET: Carreira
<<<<<<< HEAD
=======
        private CarreiraREP rep = new CarreiraREP();
>>>>>>> 4967de737a9eac122a8744372d316030fca1fb31
        public ActionResult Index()
        {
            return View();
        }
<<<<<<< HEAD
=======
        public ActionResult Lista()
        {
            //Listar todos as Empresas
            var listaCarreira = rep.Listar();
            return View(listaCarreira);
        }

        [HttpPost]
        public ActionResult Cadastrar(String Nome)
        {

            var novo = new CarreiraMOD()
            {
                Nome = Nome
            };
            rep.Adicionar(novo);
            return RedirectToAction("Lista");
        }

        public ActionResult Deletar(Int32 Codigo)
        {
            rep.Excluir(Codigo);
            return RedirectToAction("Lista");
        }

        public ActionResult Inserir()
        {
            return View();
        }

        public ActionResult Editar(Int32 Codigo)
        {
            return View(rep.Selecionar(Codigo));
        }

        [HttpPost]
        public ActionResult Atualizar(Int32 Codigo, String Nome)
        {
            var novo = new CarreiraMOD()
            {
                ID = Codigo,
                Nome = Nome
            };
            rep.Atualizar(novo);
            return RedirectToAction("Lista");
        }
>>>>>>> 4967de737a9eac122a8744372d316030fca1fb31
    }
}