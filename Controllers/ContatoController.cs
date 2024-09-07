using Microsoft.AspNetCore.Mvc;
using Trabalho_Agenda_Contatos.Auxiliar;
using Trabalho_Agenda_Contatos.Filters;
using Trabalho_Agenda_Contatos.Models;
using Trabalho_Agenda_Contatos.Repositorio;

namespace Trabalho_Agenda_Contatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        private readonly ISessao _sessao;

        public ContatoController(IContatoRepositorio contatoRepositorio, ISessao sessao)
        {
            _contatoRepositorio = contatoRepositorio;
            _sessao = sessao;
        }

        // Listar todos os contatos
        public IActionResult Index()
        {
            UsuarioModel usuariologado = _sessao.BuscarSessaoUsuario();

            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos(usuariologado.Id);
            return View(contatos);
        }

        // Exibir formulário para criação de um novo contato
        public IActionResult CriarContato()
        {
            return View();
        }

        // Exibir formulário para editar um contato existente
        public IActionResult EditarContato(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        // Exibir confirmação para apagar contato
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        // Apagar um contato
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não foi possível apagar o contato!";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, ocorreu um erro ao apagar o contato: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        // Criar um novo contato
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuariologado = _sessao.BuscarSessaoUsuario();
                    contato.UsuarioId = usuariologado.Id;

                    contato = _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("CriarContato", contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, ocorreu um erro ao cadastrar o contato: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        // Alterar um contato existente
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuariologado = _sessao.BuscarSessaoUsuario();
                    contato.UsuarioId = usuariologado.Id;

                    contato =_contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("EditarContato", contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, ocorreu um erro ao atualizar o contato: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
