using API_Cursos.Enums;

namespace API_Cursos.DTOs.Cursos
{
    public class CursoResponse
    {
        public long Id { get; set; }
        public string Nome {  get; set; }
        public PeriodoCurso Periodo { get; set; }
    }
}
