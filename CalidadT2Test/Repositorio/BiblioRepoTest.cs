using System.Collections.Generic;
using System.Linq;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using CalidadT2Test.MockDbSET;
using Moq;
using NUnit.Framework;

namespace CalidadT2Test.Repositorio;

public class BiblioRepoTest
{
    private IQueryable<Biblioteca> data;
    private Mock<AppBibliotecaContext> mockDB;
    
    [SetUp]
    public void SetUp()
    {
        data = new List<Biblioteca>
        {
            new Biblioteca(){Id = 1, UsuarioId = 1, LibroId = 1},
            new Biblioteca(){Id = 2, UsuarioId = 2, LibroId = 2}
            
        }.AsQueryable();
        
        var mockDbseBiblioteca = new MockDbSet<Biblioteca>(data);
        mockDB = new Mock<AppBibliotecaContext>();
        mockDB.Setup(o => o.Bibliotecas).Returns(mockDbseBiblioteca.Object);

    }

    [Test]
    public void ObtBiblioTest()
    {
        var repositorio = new BiblioRepo(mockDB.Object);

        var result = repositorio.ObtBiblio(1);
        
        Assert.AreEqual(1, result.Count);
    }
    
    [Test]
    public void AddBiblioTest()
    {
        var repo = new BiblioRepo(mockDB.Object);
        var result = repo.AddBiblio(new Biblioteca() {
            Id = 3, UsuarioId = 2, LibroId = 1
        });

        Assert.AreEqual(3, result.Id);
    }
    
    [Test]
    public void UpEstTest()
    {
        var repo = new BiblioRepo(mockDB.Object);
        var result = repo.UpEst(1,1);

        Assert.AreEqual(1, result.Id);
    }
}