namespace Cursos.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }

        public ICollection<EstudianteCurso> EstudiantesCursos { get; set; }
    }
}
