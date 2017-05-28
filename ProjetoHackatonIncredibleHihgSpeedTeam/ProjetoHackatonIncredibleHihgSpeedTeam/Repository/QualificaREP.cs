using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoHackatonIncredibleHihgSpeedTeam.Models;
namespace ProjetoHackatonIncredibleHihgSpeedTeam.Repository
{
    public class QualificaREP
    {
        public List<QualificaçaoMOD> Listar()
        {
            var registros = new List<QualificaçaoMOD>();
            using (var conexao = new DB_HACKATONEntities())
            {
                registros = conexao.TB_QUALIFICACAO.ToList().ConvertAll<QualificaçaoMOD>(x => new QualificaçaoMOD
                {
                    ID = x.ID,
                    Nome = x.NM_NOME
                });
            }
            return registros;
        }

        public void Adicionar(QualificaçaoMOD modelo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var novo = new TB_QUALIFICACAO
                {
                    NM_NOME = modelo_.Nome
                };
                conexao.TB_QUALIFICACAO.Add(novo);
                conexao.SaveChanges();
            }
        }

        public void Excluir(int codigo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var registro = conexao.TB_QUALIFICACAO.Single(x => x.ID == codigo_);
                conexao.TB_QUALIFICACAO.Remove(registro);
                conexao.SaveChanges();
            }
        }

        public void Atualizar(QualificaçaoMOD modelo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var registro = conexao.TB_QUALIFICACAO.Single(x => x.ID == modelo_.ID);
                registro.NM_NOME = modelo_.Nome;
                conexao.SaveChanges();
            }
        }
    }
}