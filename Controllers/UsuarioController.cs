using Microsoft.AspNetCore.Mvc;

namespace LoginCriptografado.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult CadastrarUsuario()
        {
            return View();
        }


    }
}
