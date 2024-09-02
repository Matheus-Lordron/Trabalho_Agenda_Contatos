using System.ComponentModel.DataAnnotations;

namespace Trabalho_Agenda_Contatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome do contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o e-mail do contato")]
        [EmailAddress(ErrorMessage ="O e-mail informado não é valido!")]
        public string Email { get; set;}
        [Required(ErrorMessage = "Informe o celular do contato")]
        [Phone(ErrorMessage = "O celular informado não é valido!")]
        public string Celular { get; set; }
    }
}
