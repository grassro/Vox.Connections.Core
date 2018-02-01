using Microsoft.EntityFrameworkCore;

namespace VoxConnections.Convidados.Core
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DataContext() { }

        //Adiciona os modelos das classes no contexto
        public DbSet<Usuario> Usuario { get; set; }


        //Core
        //public DbSet<AreaAtuacao> AreaAtuacao { get; set; }
        public DbSet<Curriculo> Curriculo { get; set; }
        public DbSet<IdiomaCandidato> IdiomaCandidato { get; set; }
        public DbSet<IdiomaVaga> IdiomaVaga { get; set; }
        public DbSet<IdiomaGestor> IdiomaGestor { get; set; }

        //Convidados
        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<Gestor> Gestor { get; set; }
        public DbSet<Headhunter> Headhunter { get; set; }

        //Vagas
        public DbSet<Vagas> Vagas { get; set; }
        public DbSet<VagasCandidatura> VagasCandidatura { get; set; }




    }
}
