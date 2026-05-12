using API_Cursos.Common;
using API_Cursos.DTOs.Cursos;
using API_Cursos.Enums;
using API_Cursos.Models;

namespace API_Cursos.Services
{
    public class CursoService
    {
        private readonly DbCursosContext _db;

        public CursoService(DbCursosContext db)
        {
            _db = db;
        }
        public ResultadoPadrao<object> CriarCurso(CursoRequest dto)
        {
            var nomeTurma = dto.Nome.Trim().ToUpper();

            var existe = _db.TabelaCursos.Any(c => c.Nome.ToUpper() == nomeTurma && c.IsAtivo);

            if (existe)
            {
                return ResultadoPadrao<object>.Falha("Curso ja existe", 409);
            }

            var nomeCurso = dto.Nome.Trim().ToUpper();

            var novoCurso = new TabelaCurso
            {
                Nome = nomeCurso,
                Periodo = dto.Periodo,
                IsAtivo = true
            };

            _db.TabelaCursos.Add(novoCurso);
            _db.SaveChanges();

            return ResultadoPadrao<object>.Ok(novoCurso, mensagem: "Curso criado com sucesso", 201);
        }

        public ResultadoPadrao<List<CursoResponse>> BuscarCursosAtivas()
        {
            var turmas = _db.TabelaCursos
                .Where(c => c.IsAtivo)
                .Select(c => new CursoResponse
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Periodo = c.Periodo,
                })
                .ToList();
            if(turmas.Count == 0)
                return ResultadoPadrao<List<CursoResponse>>.Falha("Nenhum curso cadastrado", 404);

            return ResultadoPadrao<List<CursoResponse>>.Ok(turmas);
        }

        public ResultadoPadrao<CursoResponse> BuscarCursosAtivosPeloId(int idCurso)
        {
            var curso = _db.TabelaCursos
                .Where(c => c.Id == idCurso && c.IsAtivo)
                .Select(c => new CursoResponse
                {
                    Nome = c.Nome,
                    Periodo = c.Periodo,
                })
                .FirstOrDefault();

            if (curso == null)
                return ResultadoPadrao<CursoResponse>.Falha("Curso não encontrado", 404);


            return ResultadoPadrao<CursoResponse>.Ok(curso);
        }

        public ResultadoPadrao<List<CursoResponse>> BuscarCursoPeloNome(string nome)
        {
            var nomeCurso = nome.Trim().ToUpper();

            var cursos = _db.TabelaCursos.Where(c => c.Nome.ToUpper().Contains(nomeCurso) && c.IsAtivo).Select(a => new CursoResponse
            {
                Id = a.Id,
                Nome = a.Nome,
                Periodo = a.Periodo,
            }).ToList();

            if (cursos.Count == 0)
                return ResultadoPadrao<List<CursoResponse>>.Falha("Nenhum curso com esse nome encontrado", 404);

            return ResultadoPadrao<List<CursoResponse>>.Ok(cursos);
        }

        public ResultadoPadrao<object> AtualizarCurso(int idCurso, CursoRequest dto)
        {
            var curso = _db.TabelaCursos.FirstOrDefault(c => c.Id == idCurso && c.IsAtivo);

            if (curso == null)
                return ResultadoPadrao<object>.Falha("Curso não encontrado", 404);

            var nomeCurso = dto.Nome.Trim().ToUpper();

            var existe = _db.TabelaCursos.Any(c => c.Id != idCurso && c.Nome.ToUpper() == nomeCurso && c.IsAtivo);

            if (existe)
                return ResultadoPadrao<object>.Falha("Já existe um curso com esse nome", 409);

            curso.Nome = nomeCurso;

            curso.Periodo = dto.Periodo;


            _db.SaveChanges();

            return ResultadoPadrao<object>.Ok(curso, "Curso atualizado com sucesso", 200);
        }

        public ResultadoPadrao<object> DeletarCurso(int idCurso)
        {
            var curso = _db.TabelaCursos.FirstOrDefault(c => c.Id == idCurso && c.IsAtivo);

            if (curso == null)
                return ResultadoPadrao<object>.Falha("Curso não encontrado", 404);

            curso.IsAtivo = false;
            _db.SaveChanges();

            return ResultadoPadrao<object>.Ok(null, "Curso excluído com sucesso", 200);
        }

        public ResultadoPadrao<List<CursoResponse>> BuscarCursoPeloPeriodo(PeriodoCurso periodo)
        {
            var cursos = _db.TabelaCursos
                .Where(c => c.Periodo == periodo && c.IsAtivo)
                .Select(c => new CursoResponse
                {
                    Nome = c.Nome,
                    Periodo = c.Periodo,
                })
                .ToList();

            if (cursos.Count == 0)
                return ResultadoPadrao<List<CursoResponse>>.Falha("Curso não encontrado", 404);


            return ResultadoPadrao<List<CursoResponse>>.Ok(cursos);
        }
    }
}
