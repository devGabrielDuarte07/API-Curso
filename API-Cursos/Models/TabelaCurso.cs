using API_Cursos.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Cursos.Models;

public partial class TabelaCurso
{
    public long Id { get; set; }

    [Required]
    [MinLength(3)]
    public string Nome { get; set; } = null!;

    [Required]
    public PeriodoCurso Periodo { get; set; }

    public bool IsAtivo { get; set; } = true;
}
