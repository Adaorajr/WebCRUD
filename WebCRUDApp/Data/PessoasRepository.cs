using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebCRUDApp.Data.Interfaces;
using WebCRUDApp.Models.Contexto;
using WebCRUDApp.Models.Entidades;
using WebCRUDApp.ViewModel;

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
        //public IEnumerable<FuncViewModel> nomePessoa(string search)
        //{
        //    return _ctx.tb_Pessoa.Where(p => p.Nome == search)
        //        .Select(p => new FuncViewModel
        //        {
        //            Id = p.Id,
        //            Nome = p.Nome,
        //            Sobrenome = p.Sobrenome,
        //            DataNascimento = p.DataNascimento,
        //            NomeCargo = p.Cargo.NomeCargo
        //        })
        //        .AsEnumerable<FuncViewModel>();
        //}
        public void Salvar(Pessoas p)
        {
            try
            {
                _ctx.Add(p);
                _ctx.SaveChanges();
            }
            catch (Exception)
            { }
        }
        public Pessoas Editar(int id)
        {
            var edit = _ctx.tb_Pessoa.Where(p => p.Id == id)
                        .Include(p => p.endereco)
                        .Include(p => p.Cargo)
                        .FirstOrDefault();
            return edit;
            //var p = _ctx.tb_Pessoa.Find(id);
            //return p;
        }
        public void Editar(Pessoas p)
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
            { }
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
        public IEnumerable<Cargo> listaCargos()
        {
            var sql = @"select*from tb_cargo c order by c.NomeCargo;";
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                var dap = conn.Query<Cargo>(sql);
                return dap;
            }
        }
    }
}
    

