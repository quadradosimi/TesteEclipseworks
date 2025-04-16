using Eclipseworks.Model;
using Microsoft.EntityFrameworkCore;

namespace Eclipseworks.Entity
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        // Registered DB Model in ApplicationDbContext file
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Historico> Historicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ProjetoTarefas> ProjetoTarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting a primary key in model
            modelBuilder.Entity<Usuario>().HasKey(x => x.Id);

            // Inserting record in table
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Nome = "Teste",
                    Funcao = "gerente"
                }
            );
        }
    }
}