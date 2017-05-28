using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoHackatonIncredibleHihgSpeedTeam.Models;

namespace ProjetoHackatonIncredibleHihgSpeedTeam.Repository
{
    public class EmpresaCarreiraREP
    {
        public List<EmpresaCarreiraMOD> Listar()
        {
            var registros = new List<EmpresaCarreiraMOD>();
            using (var conexao = new DB_HACKATONEntities())
            {
                registros = conexao.TB_EMPRESA_CARREIRA.ToList().ConvertAll<EmpresaCarreiraMOD>(x => new EmpresaCarreiraMOD
                {
                    ID = x.ID,
                    ID_Carreira = x.ID_CARREIRA,
                    ID_Empresa = x.ID_EMPRESA
                });
            }
            return registros;
        }

        public void Adicionar(EmpresaCarreiraMOD modelo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var novo = new TB_EMPRESA_CARREIRA
                {
                    ID_CARREIRA = modelo_.ID_Carreira,
                    ID_EMPRESA = modelo_.ID_Empresa
                };
                conexao.TB_EMPRESA_CARREIRA.Add(novo);
                conexao.SaveChanges();
            }
        }

        public void Excluir(int codigo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var registro = conexao.TB_EMPRESA_CARREIRA.Single(x => x.ID == codigo_);
                conexao.TB_EMPRESA_CARREIRA.Remove(registro);
                conexao.SaveChanges();
            }
        }

        public void Atualizar(EmpresaCarreiraMOD modelo_)
        {
            using (var conexao = new DB_HACKATONEntities())
            {
                var registro = conexao.TB_EMPRESA_CARREIRA.Single(x => x.ID == modelo_.ID);
                registro.ID_CARREIRA = modelo_.ID_Carreira;
                registro.ID_EMPRESA = modelo_.ID_Empresa;
                conexao.SaveChanges();
            }
        }
    }
}