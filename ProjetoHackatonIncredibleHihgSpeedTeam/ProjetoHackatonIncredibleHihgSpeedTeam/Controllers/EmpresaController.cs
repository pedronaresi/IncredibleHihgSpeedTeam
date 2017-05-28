using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoHackatonIncredibleHihgSpeedTeam.Repository;
using ProjetoHackatonIncredibleHihgSpeedTeam.Models;
namespace ProjetoHackatonIncredibleHihgSpeedTeam.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        private EmpresaREP rep = new EmpresaREP();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Lista()
        {
            //Listar todos as Empresas
            var listaEmpresa = rep.Listar();
            return View(listaEmpresa);
        }

        [HttpPost]
        public ActionResult Cadastrar(String Nome)
        {
            
            var novo = new EmpresaMOD()
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
            var novo = new EmpresaMOD()
            {
                ID = Codigo,
                Nome = Nome
            };
            rep.Atualizar(novo);
            return RedirectToAction("Lista");
        }

    }
}