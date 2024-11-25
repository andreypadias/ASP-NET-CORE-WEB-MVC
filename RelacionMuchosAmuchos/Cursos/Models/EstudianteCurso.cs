namespace Cursos.Models
{
    public class EstudianteCurso
    {
        public int Id { get; set; }

        public int IdEstudiante { get; set; }

        public Estudiante Estudiante { get; set; }

        public int IdCurso { get; set; }
        public Curso Curso { get; set; }
    }
}
