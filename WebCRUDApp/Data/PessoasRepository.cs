using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebCRUDApp.Data.Interfaces;
using WebCRUDApp.Models.Contexto;
using WebCRUDApp.Models.Entidades;

namespace WebCRUDApp.Data
{
    public class PessoasRepository : IPessoasRepository
    {
        private readonly Context _ctx;
        private readonly IConfiguration _config;
        public PessoasRepository(Context context, IConfiguration config)
        {
            _ctx = context;
            _config = config;
            

        }
        //public PessoasRepository(Context context, IConfiguration config)
        //{
        //    _ctx = context;
        //    _config = config;
        //}
        public IEnumerable<FuncViewModel> ListaFunc()
        {

            string sql = @"select p.id, p.Nome, p.SobreNome, p.DataNascimento, c.NomeCargo from tb_pessoa p
                          join tb_cargo c on c.CargoId = p.CargoId";

            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                var dap = conn.Query<FuncViewModel>(sql);
                return dap;
            }


        }
        public void Salvar(Pessoas p)
        {
            try
            {
                _ctx.Add(p);
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public object Editar(int id)
        {
            var p = _ctx.tb_Pessoa.Find(id);
            return p;
        }
        public void Editar(int id, Pessoas p)
        {
            try
            {
                _ctx.Update(p);
                _ctx.SaveChanges();
            }
            catch (Exception)
            { }
        }
        public void Deletar(int id)
        {
            try
            {
                var p = _ctx.tb_Pessoa.Where(x => x.Id == id).FirstOrDefault();
                _ctx.Remove(p);
                _ctx.SaveChanges();

            }
            catch (Exception)
            {
                //var text = "";
                //text = e.Message;
            }

        }
        public FuncViewModel Detalhes(int id)
        {

            string sql = $@"select p.id, p.nome, p.sobrenome, p.datanascimento, c.NomeCargo from tb_pessoa p
                        join tb_cargo c on p.CargoId = c.CargoId
                        where p.id = {id}";
            using (var con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                var dap = con.QueryFirstOrDefault<FuncViewModel>(sql);
                return dap;
            }

        }
    }
}
