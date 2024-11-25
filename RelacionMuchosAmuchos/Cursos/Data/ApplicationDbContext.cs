using Cursos.Models;
using Microsoft.EntityFrameworkCore;

namespace Cursos.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<EstudianteCurso>()
                .HasOne(ec => ec.Estudiante)
                .WithMany(e => e.EstudiantesCursos)
                .HasForeignKey(e => e.IdEstudiante);

            modelBuilder.Entity<EstudianteCurso>()
                .HasOne(ec => ec.Curso)
                .WithMany(c => c.EstudiantesCursos)
                .HasForeignKey(e => e.IdCurso);

        }

        public DbSet<EstudianteCurso> EstudiantesCursos { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }

        public DbSet<Curso> Cursos { get; set; }


    }
}
