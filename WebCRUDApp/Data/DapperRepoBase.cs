using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebCRUDApp.Models.Entidades;
using WebCRUDApp.Interfaces.IRepositoryBase;

namespace WebCRUDApp
{
    public class DapperRepoBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {    
        private readonly IConfiguration _configuration;
        protected readonly SqlConnection _conn; 
        public void PessoaRepository(IConfiguration config)
        {
            _configuration = config;
            _conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        }

        public Pessoas GetById(int id)
        {
            _conn;
        }

    }



}