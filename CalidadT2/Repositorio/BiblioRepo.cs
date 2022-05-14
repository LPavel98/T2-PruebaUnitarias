using System.Collections.Generic;
using System.Linq;
using CalidadT2.Constantes;
using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Repositorio
{
    public interface IBiblioRepo
    {
        List<Biblioteca> ObtBiblio(int id);
        Biblioteca AddBiblio(Biblioteca biblioteca);
        Biblioteca UpEst(int libroid, int userid);
        Biblioteca EstTerm(int libroId, int id);
    }
    public class BiblioRepo: IBiblioRepo
    {
        private AppBibliotecaContext app;

        public BiblioRepo(AppBibliotecaContext app)
        {
            this.app = app;
        }

        public List<Biblioteca> ObtBiblio(int id)
        {
          return app.Bibliotecas
                .Include(o => o.Libro.Autor)
                .Include(o => o.Usuario)
                .Where(o => o.UsuarioId == id)
                .ToList();
        }

        public Biblioteca AddBiblio(Biblioteca biblioteca)
        {
            app.Bibliotecas.Add(biblioteca);
            app.SaveChanges();

            return biblioteca;
        }

        public Biblioteca UpEst(int libroid, int userid)
        {
           var libro = app.Bibliotecas
                .Where(o => o.LibroId == libroid && o.UsuarioId == userid)
                .FirstOrDefault();

            libro.Estado = ESTADO.LEYENDO;
            app.SaveChanges();
            
            
            return libro;
        }


        public Biblioteca EstTerm(int libroId, int id)
        {
            var libro = app.Bibliotecas
                .Where(o => o.LibroId == libroId && o.UsuarioId == id)
                .FirstOrDefault();

            libro.Estado = ESTADO.TERMINADO;
            app.SaveChanges();

            return libro;

        }

    }
}