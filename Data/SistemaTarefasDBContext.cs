using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstDotNetApi.Data.Map;
using FirstDotNetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstDotNetApi.Data
{
    public class SistemaTarefasDBContext : DbContext
    {
        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options)
            :base(options)
        {}

        public DbSet<UsuarioModel> Usuarios {get; set;}
        public DbSet<TarefaModel> Tarefas {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(@"Data Source=/home/malcolm/portfolio/FirstDotNetApi/app.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}