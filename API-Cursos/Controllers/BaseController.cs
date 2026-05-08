using API_Cursos.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Cursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult Resultado<T>(ResultadoPadrao<T> resultado)
        {
            return StatusCode(resultado.StatusCode, resultado);
        }
    }
}
