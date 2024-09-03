using Microsoft.EntityFrameworkCore;
using Trabalho_Agenda_Contatos.Models;

namespace Trabalho_Agenda_Contatos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }
        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
