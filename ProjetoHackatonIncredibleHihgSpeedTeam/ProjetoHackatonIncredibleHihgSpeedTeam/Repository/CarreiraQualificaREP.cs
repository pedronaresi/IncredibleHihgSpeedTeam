using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoHackatonIncredibleHihgSpeedTeam.Models;

namespace ProjetoHackatonIncredibleHihgSpeedTeam.Repository
{
    public class CarreiraQualificaREP
    {
        public List<CarreiraQualificaMOD> Listar()
        {
            var registros = new List<CarreiraQualificaMOD>();
            using (var conexao = new DB_HACKATONEntities())
            {
                registros = conexao.TB_CARREIRA_QUALIFICA.ToList().ConvertAll<CarreiraQualificaMOD>(x => new CarreiraQualificaMOD
                {
                    ID = x.ID,
                    ID_Carreira = x.ID_CARREIRA,
                    ID_Qualificacao = x.ID_QUALIFICACAO
                });
            }
            return registros;
        }

        public void Adicionar(CarreiraQualificaMOD modelo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var novo = new TB_CARREIRA_QUALIFICA
                {
                    ID_CARREIRA = modelo_.ID_Carreira,
                    ID_QUALIFICACAO = modelo_.ID_Qualificacao
                };
                conexao.TB_CARREIRA_QUALIFICA.Add(novo);
                conexao.SaveChanges();
            }
        }

        public void Excluir(int codigo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var registro = conexao.TB_CARREIRA_QUALIFICA.Single(x => x.ID == codigo_);
                conexao.TB_CARREIRA_QUALIFICA.Remove(registro);
                conexao.SaveChanges();
            }
        }

        public void Atualizar(CarreiraQualificaMOD modelo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var registro = conexao.TB_CARREIRA_QUALIFICA.Single(x => x.ID == modelo_.ID);
                registro.ID_CARREIRA = modelo_.ID_Carreira;
                registro.ID_QUALIFICACAO = modelo_.ID_Qualificacao;
                conexao.SaveChanges();
            }
        }
    }
}