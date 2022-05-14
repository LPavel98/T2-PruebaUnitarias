using CalidadT2.Controllers;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CalidadT2Test.Controller;

public class HomeControllerTest
{
     
    [Test]
    public void IndexViewTest()
    {
        var mockRepositorioHome = new Mock<ILibroRepo>();
        
        var controller = new HomeController(null, mockRepositorioHome.Object);

        var view = (ViewResult) controller.Index();
        
        Assert.IsNotNull(view);
        Assert.IsInstanceOf<ViewResult>(view);

    }


}