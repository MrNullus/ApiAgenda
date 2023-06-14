using API.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataAccess
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext(string connString):base(connString) { }
        //entidades do banco de dados
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Contato>().ToTable("Contato");
            modelBuilder.Entity<Contato>().HasKey(t => t.ID);


        }
    }
}
