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

            return View();
        }

        public ActionResult Lista_Empresas()
        {
            //verificar qualificacoes do usuario e mostrar empresas de 75% pra cima
            //var l3 = new List<TB_CARREIRAS>();
            //using (var conexao = new DB_HACKATONEntities())
            //{
            //    foreach (var x in conexao.TB_USER_QUALIFICACAO.Where(x => x.ID_USER == 1))
            //    {
            //        foreach (var z in conexao.TB_QUALIFICACAO.Where(y => y.ID == x.ID_QUALIFICACAO))
            //        {
            //            foreach(var w in conexao.TB_CARREIRA_QUALIFICA.Where(y => y.ID_QUALIFICACAO == z.ID))
            //            {
            //                if(!l3.Exists(v => v.ID == w.ID_CARREIRA))
            //                    l3.Add(conexao.TB_CARREIRAS.Single(y => y.ID == w.ID_CARREIRA));
            //            }
            //        }
            //    }
            //}
            //var l4 = l3.ToList().ConvertAll<CarreiraMOD>(x => new CarreiraMOD
            //{
            //    ID = x.ID,
            //    Nome = x.NM_NOME
            //});
            var possivel = new List<CarreiraMOD>();
            var empresas = new List<EmpresaMOD>();
            var carreiras = new CarreirasREP();
            var carQuali = new CarreiraQualificaREP();
            using (var conexao = new DB_HACKATONEntities())
            {
                foreach (var carr in carreiras.Listar())
                {
                    var l1 = new List<TB_QUALIFICACAO>();
                    foreach (var x in conexao.TB_CARREIRA_QUALIFICA.Where(y => y.ID_CARREIRA == carr.ID)){
                        l1.Add(conexao.TB_QUALIFICACAO.Single(z => z.ID == x.ID_QUALIFICACAO));
                    }
                    foreach(var x in conexao.TB_USER_QUALIFICACAO.Where(y => y.ID_USER == 1))
                    {
                        if (l1.Exists(v => v.ID == x.ID_QUALIFICACAO))
                            l1.Remove(l1.Single(v => v.ID == x.ID_QUALIFICACAO));
                        if(l1.Count() == 0)
                        {
                            if(!possivel.Exists(v => v.ID == carr.ID))
                                possivel.Add(carr);
                        }

                    }
                }
                foreach(var x in possivel)
                {
                    foreach(var y in conexao.TB_EMPRESA_CARREIRA.Where(c => c.ID_CARREIRA == x.ID))
                    {
                        empresas.Add(new EmpresaMOD { ID = y.ID_EMPRESA, Nome = y.TB_EMPRESA.NM_NOME });
                    }
                }
            }
            return View(empresas);
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

    }
}
