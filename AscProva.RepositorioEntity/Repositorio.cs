using AscProva.Modelo;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AscProva.RepositorioEntity
{
    public class Repositorio : DbContext
    {

        public Repositorio()
            : base("ConexaoDb")
        {
        }

        public DbSet<Alunos> Alunos { get; set; }
      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
