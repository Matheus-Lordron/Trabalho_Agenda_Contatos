using System.ComponentModel.DataAnnotations;

namespace Trabalho_Agenda_Contatos.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Informe o login do usuário")]
        public string Login {  get; set; }
        [Required(ErrorMessage = "Informe a senha do usuário")]
        public string Senha { get; set; }
    }
}
