using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoHackatonIncredibleHihgSpeedTeam.Repository;
using ProjetoHackatonIncredibleHihgSpeedTeam.Models;

namespace ProjetoHackatonIncredibleHihgSpeedTeam.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            ViewBag.User = TempData.Peek("User");
            return View();
        }

        public ActionResult Lista_Empresas()
        {
            var possivel = new List<CarreiraMOD>();
            var empresas = new List<EmpresaMOD>();
            var rep = new EmpresaREP();
            var carQuali = new CarreiraQualificaREP();
            using (var conexao = new DB_HACKATONEntities())
            {
                foreach(var x in conexao.TB_EMPRESA_CARREIRA.ToList<TB_EMPRESA_CARREIRA>())
                {
                    empresas.Add(new EmpresaMOD { ID = x.ID, Nome = x.TB_EMPRESA.NM_NOME, Carreira = new CarreiraMOD {ID=x.TB_CARREIRAS.ID,Nome = x.TB_CARREIRAS.NM_NOME } });
                }
                //    foreach (var carr in carreiras.Listar())
                //    {
                //        var l1 = new List<TB_QUALIFICACAO>();
                //        foreach (var x in conexao.TB_CARREIRA_QUALIFICA.Where(y => y.ID_CARREIRA == carr.ID))
                //        {
                //            l1.Add(conexao.TB_QUALIFICACAO.Single(z => z.ID == x.ID_QUALIFICACAO));
                //        }
                //        foreach (var x in conexao.TB_USER_QUALIFICACAO.Where(y => y.ID_USER == 1))
                //        {
                //            if (l1.Exists(v => v.ID == x.ID_QUALIFICACAO))
                //                l1.Remove(l1.Single(v => v.ID == x.ID_QUALIFICACAO));
                //            if (l1.Count() == 0)
                //            {
                //                if (!possivel.Exists(v => v.ID == carr.ID))
                //                    possivel.Add(carr);
                //            }
                //        }
                //    }
                //    foreach (var x in possivel)
                //    {
                //        //foreach (var y in conexao.TB_EMPRESA_CARREIRA.Where(c => c.ID_CARREIRA == x.ID))
                //        //{
                //            empresas.Add(new EmpresaMOD { ID = x.ID_EMPRESA, Nome = x.TB_EMPRESA.NM_NOME, Carreira = new CarreiraMOD { ID = x.ID, Nome = x.Nome } });
                //        //}
                //    }
            }
            ViewBag.User = TempData.Peek("User");
            return View(empresas);
        }

        public ActionResult Lista_Escolas()
        {
            //Listar escolas q fornecem os cursos nescessarios

            ViewBag.User = TempData.Peek("User");
            return View();
        }

        public ActionResult Qualificaçao(Int32 Codigo)
        {
            var y = new TB_CARREIRAS();
            var lista = new List<QualificaçaoMOD>();
            using (var conexao = new DB_HACKATONEntities())
            {
                foreach (var x in conexao.TB_CARREIRA_QUALIFICA.Where(c => c.ID_CARREIRA == Codigo))
                {
                    lista.Add(new QualificaçaoMOD { ID = x.ID_QUALIFICACAO, Nome = x.TB_QUALIFICACAO.NM_NOME });
                }
                y = conexao.TB_CARREIRAS.Single(c => c.ID == Codigo);
            }
            ViewBag.nmVaga = y.NM_NOME;
            ViewBag.User = TempData.Peek("User");
            return View(lista);
        }

        public ActionResult Lista_Qualificacoes()
        {
            //Listar escolas q fornecem os cursos nescessarios
            var rep = new QualificaREP();
            var lista = rep.Listar();
            ViewBag.User = TempData.Peek("User");
            return View(lista);
        }

        public ActionResult Buscar_Escolas(Int32 Codigo)
        {
            var y = new TB_QUALIFICACAO();
            var l1 = new List<EscolaMOD>();
            using (var conexao = new DB_HACKATONEntities())
            {
                foreach (var x in conexao.TB_ESCOLA_QUALIFICA.Where(c => c.ID_QUALIFICACAO == Codigo))
                {
                    l1.Add(new EscolaMOD { ID = x.ID, Nome = x.TB_ESCOLA.NM_NOME });
                }
                y = conexao.TB_QUALIFICACAO.Single(c => c.ID == Codigo);
            }
            ViewBag.nmCurso = y.NM_NOME;
            ViewBag.User = TempData.Peek("User");
            return View(l1);
        }

        public ActionResult Perfil()
        {
            ViewBag.User = TempData.Peek("User");
            return View();
        }

        public ActionResult Deslogar()
        {
            var lixo = TempData["User"];
            return RedirectToAction("Index", "Home");
        }

    }
}
