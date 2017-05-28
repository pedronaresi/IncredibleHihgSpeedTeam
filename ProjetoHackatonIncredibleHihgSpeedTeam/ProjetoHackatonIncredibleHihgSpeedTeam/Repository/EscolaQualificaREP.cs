using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoHackatonIncredibleHihgSpeedTeam.Models;

namespace ProjetoHackatonIncredibleHihgSpeedTeam.Repository
{
    public class EscolaQualificaREP
    {
        public List<EscolaQualificaMOD> Listar()
        {
            var registros = new List<EscolaQualificaMOD>();
            using (var conexao = new DB_HACKATONEntities())
            {
                registros = conexao.TB_ESCOLA_QUALIFICA.ToList().ConvertAll<EscolaQualificaMOD>(x => new EscolaQualificaMOD
                {
                    ID = x.ID,
                    ID_Escola = x.ID_ESCOLA,
                    ID_Qualifica = x.ID_QUALIFICACAO
                });
            }
            return registros;
        }

        public void Adicionar(EscolaQualificaMOD modelo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var novo = new TB_ESCOLA_QUALIFICA
                {
                    ID_ESCOLA = modelo_.ID_Escola,
                    ID_QUALIFICACAO = modelo_.ID_Qualifica
                };
                conexao.TB_ESCOLA_QUALIFICA.Add(novo);
                conexao.SaveChanges();
            }
        }

        public void Excluir(int codigo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var registro = conexao.TB_ESCOLA_QUALIFICA.Single(x => x.ID == codigo_);
                conexao.TB_ESCOLA_QUALIFICA.Remove(registro);
                conexao.SaveChanges();
            }
        }

        public void Atualizar(EscolaQualificaMOD modelo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var registro = conexao.TB_ESCOLA_QUALIFICA.Single(x => x.ID == modelo_.ID);
                registro.ID_ESCOLA = modelo_.ID_Escola;
                registro.ID_QUALIFICACAO = modelo_.ID_Qualifica;
            }
        }
    }
}