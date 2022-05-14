using System.Collections.Generic;
using System.Linq;
using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Repositorio
{
    public interface ILibroRepo
    {
        List<Libro> ObtLibro();
        Libro ObtLibroId(int id);
        Libro AddComment(Comentario comentario);
    }
    public class LibroRepo: ILibroRepo
    {
        private AppBibliotecaContext app;

        public LibroRepo(AppBibliotecaContext app)
        {
            this.app = app;
        }

        public List<Libro> ObtLibro()
        {
          return app.Libros.Include(o => o.Autor).ToList();
        }

        public Libro ObtLibroId(int id)
        {
            return app.Libros
                .Include("Autor")
                .Include("Comentarios.Usuario")
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }
        
        public Libro AddComment(Comentario comentario)
        {
            app.Comentarios.Add(comentario);

            var libro = app.Libros.Where(o => o.Id == comentario.LibroId).FirstOrDefault();
            libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;

            app.SaveChanges();

            return libro;
        }

    }
}