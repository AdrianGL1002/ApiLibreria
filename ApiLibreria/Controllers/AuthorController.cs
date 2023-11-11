using apiExamen.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using apiExamen.Models;
using apiExamen.Operaciones;

namespace ApiLibreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private AuthorDAO autorDao = new AuthorDAO();
        [HttpGet("AuthorAll")]
        public List<Author> seleccionarAutores() 
        {
            return autorDao.seleccionarTodosAuthores();
        }

        [HttpPost("PAuthors")]
        public bool insertarAutores([FromBody] Author autores) {
            return autorDao.insertarAutores(autores.Named);
        }
    }
}
