using LoginCriptografado.Models;
using LoginCriptografado.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoginCriptografado.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsuarioService _usuarioService;
        
        public HomeController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet]
        public IActionResult Login()
        {    
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            if(_usuarioService.RealizarLogin(email, senha) != true)
            {
                return RedirectToAction("Login", "Home"); 
            }
            return RedirectToAction("Logado", "Usuario");
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
