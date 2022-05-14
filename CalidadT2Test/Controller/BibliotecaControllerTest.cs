using System.Collections.Generic;
using System.Security.Claims;
using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CalidadT2Test.Controller;

public class BibliotecaControllerTest
{
    
    
    [Test]
    public void IndexTest()
    {
        var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
        mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>() {
            new Claim(ClaimTypes.Name, "admin")
        });

        var mockContext = new Mock<HttpContext>();
        mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

        var mockUserRepo = new Mock<IUserRepo>();
        mockUserRepo.Setup(o => o.LogUser("admin")).Returns(new Usuario());

        var cont = new BibliotecaController(null, mockUserRepo.Object, null);
        cont.ControllerContext = new ControllerContext()
        {
            HttpContext = mockContext.Object
        };
        var qwerty = cont.Index;

        Assert.IsNotNull(qwerty);
    }
    
    
    [Test]
    public void AddViewTest()
    {
        var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
        mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>() {
            new Claim(ClaimTypes.Name, "admin")
        });

        var mockContext = new Mock<HttpContext>();
        mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

        var mockUserRepo = new Mock<IUserRepo>();
        mockUserRepo.Setup(o => o.LogUser("admin")).Returns(new Usuario());

        var mockBibliotecaRepo = new Mock<IBiblioRepo>();

        var cont = new BibliotecaController(null, mockUserRepo.Object, mockBibliotecaRepo.Object);
        cont.ControllerContext = new ControllerContext()
        {
            HttpContext = mockContext.Object
        };
        var qwerty = cont.Add(1);

        Assert.IsNotNull(qwerty);
    }
    
    
    [Test]
    public void MarcarComoLeyendoTest()
    {
        var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
        mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>() {
            new Claim(ClaimTypes.Name, "admin")
        });

        var mockContext = new Mock<HttpContext>();
        mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

        var mockUserRepo = new Mock<IUserRepo>();
        mockUserRepo.Setup(o => o.LogUser("admin")).Returns(new Usuario());

        var mockBibliotecaRepo = new Mock<IBiblioRepo>();

        var cont = new BibliotecaController(null, mockUserRepo.Object, mockBibliotecaRepo.Object);
        cont.ControllerContext = new ControllerContext()
        {
            HttpContext = mockContext.Object
        };
        var qwerty = cont.MarcarComoLeyendo(1);

        Assert.IsNotNull(qwerty);
    }
    
    [Test]
    public void EstTermTest()
    {
        var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
        mockClaimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>() {
            new Claim(ClaimTypes.Name, "admin")
        });

        var mockContext = new Mock<HttpContext>();
        mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

        var mockUserRepo = new Mock<IUserRepo>();
        mockUserRepo.Setup(o => o.LogUser("admin")).Returns(new Usuario());

        var mockBibliotecaRepo = new Mock<IBiblioRepo>();

        var cont = new BibliotecaController(null, mockUserRepo.Object, mockBibliotecaRepo.Object);
        cont.ControllerContext = new ControllerContext()
        {
            HttpContext = mockContext.Object
        };
        var qwerty = cont.MarcarComoTerminado(1);

        Assert.IsNotNull(qwerty);
    }
}