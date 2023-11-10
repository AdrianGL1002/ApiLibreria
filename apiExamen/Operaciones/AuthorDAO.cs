using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apiExamen.Context;
using apiExamen.Models;

namespace apiExamen.Operaciones
{
    public class AuthorDAO
    {
        //Creamos el objeto con el contexto
        public LibreriaContext context = new LibreriaContext();

        //Metodo para seleccionar a todos los authores
        public List<BookAuthor> seleccionarTodosAuthores() {
            /* var authors = context.Authors.ToList<Author>();
             return authors;*/
            var books = from a in context.Authors
                        join b in context.Books on a.Id
                        equals b.AuthorId
                        select new BookAuthor
                        {
                            Id = a.Id,
                            Named =a.Named,
                            Title = b.Title
                            
                        };
            return books.ToList();
        }

        //Metodo para crear nuevos autores
        public bool insertarAutores(string nombre) {
            try {  
                Author author = new Author();
                author.Named = nombre;
                context.Authors.Add(author);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
