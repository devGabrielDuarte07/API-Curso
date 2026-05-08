using API_Cursos.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API_Cursos.DTOs.Cursos
{
    public class CursoRequest
    {
        [Required]
        [MinLength(3)]
        [DefaultValue("Nome do curso")]
        public string Nome { get; set; }
        [Required]
        public PeriodoCurso Periodo { get; set; }
    }
}
