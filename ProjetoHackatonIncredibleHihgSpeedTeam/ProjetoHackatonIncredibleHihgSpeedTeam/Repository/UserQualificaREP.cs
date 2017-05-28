using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoHackatonIncredibleHihgSpeedTeam.Models;

namespace ProjetoHackatonIncredibleHihgSpeedTeam.Repository
{
    public class UserQualificaREP
    {
        public List<UserQualificaMOD> Listar()
        {
            var registros = new List<UserQualificaMOD>();
            using (var conexao = new DB_HACKATONEntities())
            {
                registros = conexao.TB_USER_QUALIFICACAO.ToList().ConvertAll<UserQualificaMOD>(x => new UserQualificaMOD
                {
                    ID = x.ID,
                    ID_User = x.ID_USER,
                    ID_Qualifica = x.ID_QUALIFICACAO
                });
            }
            return registros;
        }

        public void Adicionar(UserQualificaMOD modelo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var novo = new TB_USER_QUALIFICACAO
                {
                    ID_QUALIFICACAO = modelo_.ID_Qualifica,
                    ID_USER = modelo_.ID_User
                };
                conexao.TB_USER_QUALIFICACAO.Add(novo);
                conexao.SaveChanges();
            }
        }

        public void Excluir(int codigo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var registro = conexao.TB_USER_QUALIFICACAO.Single(x => x.ID == codigo_);
                conexao.TB_USER_QUALIFICACAO.Remove(registro);
                conexao.SaveChanges();
            }
        }

        public void Atualizar(UserQualificaMOD modelo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var registro = conexao.TB_USER_QUALIFICACAO.Single(x => x.ID == modelo_.ID);
                registro.ID_QUALIFICACAO = modelo_.ID_Qualifica;
                conexao.SaveChanges();
            }
        }
    }
}