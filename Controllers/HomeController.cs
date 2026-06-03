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
            var mensagem = _usuarioService.ValidarLogin(email, senha);
            if(mensagem != null)
            {
                TempData["Mensagem"] = mensagem; 
                return RedirectToAction("Login", "Home");

            }
            if (_usuarioService.RealizarLogin(email, senha) != true)
            {
                TempData["Mensagem"] = "Erro no login.";
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
