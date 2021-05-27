using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebCRUDApp.Models.Contexto;

namespace WebCRUDApp.Data
{
    public class BaseRepository
    {
        private readonly Context _ctx;
        private IConfiguration _config;

        protected SqlConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));

        public BaseRepository(Context context, IConfiguration config)
        {
            _ctx = context;
            _config = config;
        }
    }
}
