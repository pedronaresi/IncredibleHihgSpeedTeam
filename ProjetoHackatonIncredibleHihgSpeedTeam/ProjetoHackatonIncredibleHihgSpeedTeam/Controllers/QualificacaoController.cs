using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoHackatonIncredibleHihgSpeedTeam.Repository;
using ProjetoHackatonIncredibleHihgSpeedTeam.Models;


namespace ProjetoHackatonIncredibleHihgSpeedTeam.Controllers
{
    public class QualificacaoController : Controller
    {
        private QualificaREP rep = new QualificaREP();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Lista()
        {
            //Listar todos as Empresas
            var listaQualifica = rep.Listar();
            return View(listaQualifica);
        }

        [HttpPost]
        public ActionResult Cadastrar(String Nome)
        {

            var novo = new QualificaçaoMOD()
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

        [HttpPost]
        public ActionResult Atualizar(Int32 Codigo, String Nome)
        {
            var novo = new QualificaçaoMOD()
            {
                ID = Codigo,
                Nome = Nome
            };
            rep.Atualizar(novo);
            return RedirectToAction("Lista");
        }
    }
}