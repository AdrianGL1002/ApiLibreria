using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using apiExamen.Operaciones;
using apiExamen.Models;

namespace ApiLibreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookDAO bookDao = new BookDAO();

        [HttpGet("AllBooks")]
        public List<AuthorBook> getLibros() { 
            return bookDao.seleccionarTodosLibros();
        }

        [HttpGet("OneBook")]
        public List<AuthorBook> getLibro(string libro) {
            return bookDao.seleccionar(libro);
        }

        [HttpPost("InBook")]
        public bool insertarLibro([FromBody] Book book) {
            return bookDao.insertarLibros(book.Title, book.Chapters, book.Pages, book.Price, book.AuthorId, book.Author);
        }
    }
}
