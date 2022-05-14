using System.Collections.Generic;
using System.Linq;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using CalidadT2Test.MockDbSET;
using Moq;
using NUnit.Framework;

namespace CalidadT2Test.Repositorio;

public class LibroRepoTest
{
    private IQueryable<Libro> data;
    private Mock<AppBibliotecaContext> mockDB;
    
    [SetUp]
    public void SetUp()
    {
        data = new List<Libro>
        {
            new Libro(){Id = 1, Nombre = "w", Imagen = "w1", Puntaje = 5},
            new Libro(){Id = 2, Nombre = "x", Imagen = "x1", Puntaje = 5},
            new Libro(){Id = 3, Nombre = "y", Imagen = "y1", Puntaje = 5},
            new Libro(){Id = 4, Nombre = "z", Imagen = "z1", Puntaje = 5}
        }.AsQueryable();
        
        var mockDbseLibro = new MockDbSet<Libro>(data);
        mockDB = new Mock<AppBibliotecaContext>();
        mockDB.Setup(o => o.Libros).Returns(mockDbseLibro.Object);

    }

    [Test]
    public void ObtLibroTest()
    {
        var repo = new LibroRepo(mockDB.Object);

        var result = repo.ObtLibro();
        
        Assert.AreEqual(4, result.Count);
    }
    
    [Test]
    public void ObtLibroIdTest()
    {
        var repo = new LibroRepo(mockDB.Object);

        var result = repo.ObtLibroId(1);
        
        Assert.AreEqual(1, result.Id);
    }

}