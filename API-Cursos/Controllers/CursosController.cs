using API_Cursos.DTOs.Cursos;
using API_Cursos.Enums;
using API_Cursos.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Cursos.Controllers;

/// <summary>
/// Controller responsável pelo gerenciamento de cursos.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CursosController : BaseController
{
    private readonly CursoService _cursoService;

    public CursosController(CursoService cursoService)
    {
        _cursoService = cursoService;
    }

    /// <summary>
    /// Cadastra um novo curso.
    /// </summary>
    /// <param name="dto">Dados do curso.</param>
    /// <returns>Curso criado com sucesso.</returns>
    /// <response code="201">Curso criado com sucesso.</response>
    /// <response code="409">Já existe um curso com esse nome.</response>
    [HttpPost]
    public IActionResult CriarCurso(CursoRequest dto)
    {
        return Resultado(_cursoService.CriarCurso(dto));
    }

    /// <summary>
    /// Lista todos os cursos ativos.
    /// </summary>
    /// <returns>Lista de cursos.</returns>
    /// <response code="200">Cursos encontrados com sucesso.</response>
    [HttpGet]
    public IActionResult BuscarCurso()
    {
        return Resultado(_cursoService.BuscarCursosAtivas());
    }

    /// <summary>
    /// Busca um curso ativo pelo ID.
    /// </summary>
    /// <param name="idCurso">ID do curso.</param>
    /// <returns>Curso encontrado.</returns>
    /// <response code="200">Curso encontrado com sucesso.</response>
    /// <response code="404">Curso não encontrado.</response>
    [HttpGet("{idCurso}")]
    public IActionResult BuscarCursoPeloId(int idCurso)
    {
        return Resultado(_cursoService.BuscarCursosAtivosPeloId(idCurso));
    }

    /// <summary>
    /// Atualiza um curso existente.
    /// </summary>
    /// <param name="idCurso">ID do curso.</param>
    /// <param name="dto">Novos dados do curso.</param>
    /// <returns>Curso atualizado.</returns>
    /// <response code="200">Curso atualizado com sucesso.</response>
    /// <response code="404">Curso não encontrado.</response>
    /// <response code="409">Já existe um curso com esse nome.</response>
    [HttpPut("{idCurso}")]
    public IActionResult AtualizarCurso(int idCurso, CursoRequest dto)
    {
        return Resultado(_cursoService.AtualizarCurso(idCurso, dto));
    }

    /// <summary>
    /// Realiza exclusão lógica de um curso.
    /// </summary>
    /// <param name="idCurso">ID do curso.</param>
    /// <returns>Curso deletado.</returns>
    /// <response code="204">Curso deletado com sucesso.</response>
    /// <response code="404">Curso não encontrado.</response>
    [HttpDelete("{idCurso}")]
    public IActionResult DeletarCurso(int idCurso)
    {
        return Resultado(_cursoService.DeletarCurso(idCurso));
    }

    /// <summary>
    /// Retorna todos os períodos disponíveis.
    /// </summary>
    /// <returns>Lista de períodos.</returns>
    /// <response code="200">Períodos encontrados com sucesso.</response>
    /// <response code="404">Curso não encontrado.</response>
    [HttpGet("periodo")]
    public IActionResult BuscarCursoPeloPeriodo(PeriodoCurso periodo)
    {
        return Resultado(_cursoService.BuscarCursoPeloPeriodo(periodo));
    }
}