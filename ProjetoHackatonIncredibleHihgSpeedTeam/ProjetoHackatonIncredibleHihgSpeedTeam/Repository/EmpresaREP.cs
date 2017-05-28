using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoHackatonIncredibleHihgSpeedTeam.Models;

namespace ProjetoHackatonIncredibleHihgSpeedTeam.Repository
{
    public class EmpresaREP
    {
        public List<EmpresaMOD> Listar()
        {
            var registros = new List<EmpresaMOD>();
            using (var conexao = new DB_HACKATONEntities())
            {
                registros = conexao.TB_EMPRESA.ToList().ConvertAll<EmpresaMOD>(x => new EmpresaMOD
                {
                    ID = x.ID,
                    Nome = x.NM_NOME
                });
            }
            return registros;
        }

        public void Adicionar(EmpresaMOD modelo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var novo = new TB_EMPRESA
                {
                    NM_NOME = modelo_.Nome
                };
                conexao.TB_EMPRESA.Add(novo);
                conexao.SaveChanges();
            }
        }

        public void Excluir(int codigo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var registro = conexao.TB_EMPRESA.Single(x => x.ID == codigo_);
                conexao.TB_EMPRESA.Remove(registro);
                conexao.SaveChanges();
            }
        }

        public void Atualizar(EmpresaMOD modelo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var registro = conexao.TB_EMPRESA.Single(x => x.ID == modelo_.ID);
                registro.NM_NOME = modelo_.Nome;
                conexao.SaveChanges();
            }
        }

        public EmpresaMOD Selecionar(Int32 codigo_)
        {
            var registro = new EmpresaMOD();
            using (var conexao = new DB_HACKATONEntities())
            {
                var antigo = conexao.TB_EMPRESA.Single(x => x.ID == codigo_);
                registro.ID = antigo.ID;
                registro.Nome = antigo.NM_NOME;
            }
            return registro;
        }
    }
}