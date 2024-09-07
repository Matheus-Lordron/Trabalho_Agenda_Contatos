using System.ComponentModel.DataAnnotations;

namespace Trabalho_Agenda_Contatos.Models
{
    public abstract class PessoaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o e-mail")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string Email { get; set; }
    }
}
