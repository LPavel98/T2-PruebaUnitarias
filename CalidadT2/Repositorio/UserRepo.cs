using System.Linq;
using CalidadT2.Models;

namespace CalidadT2.Repositorio
{
    public interface IUserRepo
    {
        Usuario LogUser(string user);
    }

    public class UserRepo: IUserRepo

    {
        private readonly AppBibliotecaContext app;

        public UserRepo(AppBibliotecaContext app)
        {
            this.app = app;
        }
        public Usuario LogUser(string user)
        {
           return app.Usuarios.Where(o => o.Username == user).FirstOrDefault();
           
        }

    }
}