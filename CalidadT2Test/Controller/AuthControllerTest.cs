using CalidadT2.Controllers;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CalidadT2Test.Controller;

public class AuthControllerTest
{
    [Test]
    public void LoginTest()
    {
        var cont = new AuthController(null);

        var log = (ViewResult) cont.Login();
        
        Assert.IsNotNull(log);
        Assert.IsInstanceOf<ViewResult>(log);
    }
}