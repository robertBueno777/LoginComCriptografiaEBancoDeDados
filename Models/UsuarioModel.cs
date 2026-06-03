namespace LoginCriptografado.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string? NomeUsuario { get; set; }
        public string? EmailUsuario { get; set; } 
        public string? SenhaUsuario { get; set; }
        public string? NomeCompletoUsuario { get; set; }

        public int LoginId { get; set; }
        public LoginUsuarioModel Login { get; set; } = new LoginUsuarioModel();



    }
}
