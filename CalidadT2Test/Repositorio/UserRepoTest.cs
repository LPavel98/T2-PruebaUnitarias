using System.Collections.Generic;
using System.Linq;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using CalidadT2Test.MockDbSET;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;

namespace CalidadT2Test.Repositorio;

public class UserRepoTest
{
    private IQueryable<Usuario> data;
    private Mock<AppBibliotecaContext> mockDB;
    
    [SetUp]
    public void SetUp()
    {
        data = new List<Usuario>
        {
            new Usuario(){Id = 1, Username = "admin", Password = "123456", Nombres = "Pedro"},
            new Usuario(){Id = 2, Username = "admin2", Password = "123456", Nombres = "Paco"}
            
        }.AsQueryable();
        
        var mockDbseUsuario = new MockDbSet<Usuario>(data);
        mockDB = new Mock<AppBibliotecaContext>();
        mockDB.Setup(o => o.Usuarios).Returns(mockDbseUsuario.Object);

    }

    [Test]
    public void ObtLogUserTest()
    {
        var repouser = new UserRepo(mockDB.Object);

        var result = repouser.LogUser("admin");
        
        Assert.AreEqual("admin", result.Username);
    }
}