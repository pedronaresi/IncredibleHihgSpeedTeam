using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoHackatonIncredibleHihgSpeedTeam.Models;

namespace ProjetoHackatonIncredibleHihgSpeedTeam.Repository
{
    public class EscolaREP
    {
        public List<EscolaMOD> Listar()
        {
            var registros = new List<EscolaMOD>();
            using (var conexao = new DB_HACKATONEntities())
            {
                registros = conexao.TB_ESCOLA.ToList().ConvertAll<EscolaMOD>(x => new EscolaMOD
                {
                    ID = x.ID,
                    Nome = x.NM_NOME
                });
            }
            return registros;
        }

        public void Adicionar(EscolaMOD modelo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var novo = new TB_ESCOLA
                {
                    NM_NOME = modelo_.Nome
                };
                conexao.TB_ESCOLA.Add(novo);
                conexao.SaveChanges();
            }
        }

        public void Excluir(int codigo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var registro = conexao.TB_ESCOLA.Single(x => x.ID == codigo_);
                conexao.TB_ESCOLA.Remove(registro);
                conexao.SaveChanges();
            }
        }

        public void Atualizar(EscolaMOD modelo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var registro = conexao.TB_ESCOLA.Single(x => x.ID == modelo_.ID);
                registro.NM_NOME = modelo_.Nome;
                conexao.SaveChanges();
            }
        }

    }
}