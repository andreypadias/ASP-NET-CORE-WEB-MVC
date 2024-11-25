namespace Cursos.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public ICollection<EstudianteCurso> EstudiantesCursos { get; set; }
    }
}
