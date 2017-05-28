using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoHackatonIncredibleHihgSpeedTeam.Models;

namespace ProjetoHackatonIncredibleHihgSpeedTeam.Repository
{
    public class CarreirasREP
    {
        public List<CarreiraMOD> Listar()
        {
            var registros = new List<CarreiraMOD>();
            using (var conexao = new DB_HACKATONEntities())
            {
                registros = conexao.TB_CARREIRAS.ToList().ConvertAll<CarreiraMOD>(x => new CarreiraMOD
                {
                    ID = x.ID,
                    Nome = x.NM_NOME
                });
            }
            return registros;
        }

        public void Adicionar(CarreiraMOD modelo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var novo = new TB_CARREIRAS
                {
                    NM_NOME = modelo_.Nome
                };
                conexao.TB_CARREIRAS.Add(novo);
                conexao.SaveChanges();
            }
        }

        public void Excluir(int codigo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var registro = conexao.TB_CARREIRAS.Single(x => x.ID == codigo_);
                conexao.TB_CARREIRAS.Remove(registro);
                conexao.SaveChanges();
            }
        }

        public void Atualizar(CarreiraMOD modelo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var registro = conexao.TB_CARREIRAS.Single(x => x.ID == modelo_.ID);
                registro.NM_NOME = modelo_.Nome;
                conexao.SaveChanges();
            }
        }
    }
}