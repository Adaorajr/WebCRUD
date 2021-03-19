using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCRUDApp.Models.Entidades;

namespace WebCRUDApp.Models.Contexto
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        { }
        public DbSet<Pessoas> tb_Pessoa { get; set; }
        public DbSet<Cargo> tb_Cargo { get; set; }
     
    }
}
