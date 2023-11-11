using apiExamen.Context;
using apiExamen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace apiExamen.Operaciones
{
    public class BookDAO
    {
        //Creamos un objeto de contexto BD
        public LibreriaContext contexto = new LibreriaContext();

        //Metodo para seleccionar a todos los libros
        public List<AuthorBook> seleccionarTodosLibros()
        {
            /*var books = contexto.Books.ToList();
            return books;
            */
            var books = from b in contexto.Books
                        join a in contexto.Authors on b.AuthorId
                        equals a.Id
                        select new AuthorBook
                        {
                            id = b.Id,
                            title = b.Title,
                            chapters = b.Chapters,
                            pages = b.Pages,
                            price = b.Price,
                            autor = a.Named
                        };
            return books.ToList();
        }

        public List<AuthorBook> seleccionar(string titulo) {
            //var books = contexto.Books.Where(a => a.Title == titulo).FirstOrDefault();
            var books = from b in contexto.Books
                        join a in contexto.Authors on b.AuthorId 
                        equals a.Id
                        where (b.Title == titulo)
                        select new AuthorBook
                        {
                            id = b.Id,
                            title = b.Title,
                            chapters = b.Chapters,
                            pages = b.Pages,
                            price = b.Price,
                            autor = a.Named
                        };
            return books.ToList();
        }

        public bool insertarLibros(string titulo, int capitulos, int paginas, int precio, int id_author, Author autor) 
        {
            try
            {
                Book books = new Book();
                books.Title = titulo;
                books.Chapters = capitulos;
                books.Pages = paginas;
                books.Price = precio;
                books.AuthorId = id_author;
                if (autor != null)
                {
                    books.Author = autor;
                }
                contexto.Books.Add(books);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
        /*
        public Book seleccionarId(int id) 
        {
            var books = contexto.Books.Where(a => a.Id == id).FirstOrDefault();
            return books;
        }
        
        public bool actualizarLibro(int id, string titulo, int capitulos, int paginas, int precio, int autor_id)
        {
            try 
            {
                //Seleccionar un libro
                var book = seleccionarId(id);
                if (book == null)
                {
                    return false;
                }
                else{
                    book.Id = id;
                    book.Title = titulo;
                    book.Chapters = capitulos;
                    book.Pages = paginas;
                    book.Price = precio;
                    book.AuthorId = autor_id;

                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
        */

        
    }
}
