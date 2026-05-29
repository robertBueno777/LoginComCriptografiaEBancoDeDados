using LoginCriptografado.Models;
using LoginCriptografado.Repository;
using LoginCriptografado.Interfaces;
using LoginCriptografado.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoginCriptografado.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuaarioRepository;
        public UsuarioController(UsuarioService usuarioService, IUsuarioRepository iUsuarioRepository)
        {
            _usuarioService = usuarioService;
            _usuaarioRepository = iUsuarioRepository;

        }
        [HttpGet]
        public IActionResult CadastrarUsuario()
        {
            return View(new UsuarioModel());
        }
        [HttpPost]
        public IActionResult CadastrarUsuario(UsuarioModel usuarioModel, string senhaConfirm)
        {
            _usuarioService.CadastrarUsuario(usuarioModel, senhaConfirm);
            return RedirectToAction("Index", "Home");
        }
    
    }
}
