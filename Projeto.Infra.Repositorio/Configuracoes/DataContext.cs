using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using Projeto.Infra.Repositorio.Mapeamentos;
using Projeto.Entidades;

namespace Projeto.Infra.Repositorio.Configuracoes
{
    public class DataContext : DbContext
    {

        public DataContext()  
            : base(ConfigurationManager.ConnectionStrings["techdog"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Configurations.Add(new UsuarioMap());


            //Remover os cascade
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Remover nomes pluralizados
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

     
        public DbSet<Usuario> Usuario { get; set; }
    }
}
