using Microsoft.AspNetCore.Mvc;
using Trabalho_Agenda_Contatos.Enums;
using Trabalho_Agenda_Contatos.Filters;
using Trabalho_Agenda_Contatos.Models;
using Trabalho_Agenda_Contatos.Repositorio;

namespace Trabalho_Agenda_Contatos.Controllers
{
    [PaginaRestritaAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        // Action para listar todos os usuários
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        // Action para exibir a página de criação de um novo usuário
        public IActionResult CriarUsuario()
        {
            return View();
        }

        // Action para editar um usuário
        public IActionResult EditarUsuario(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        // Action para confirmar exclusão de usuário
        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        // Action para apagar um usuário
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não foi possível apagar esse usuário!";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível apagar seu usuário, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        // Action para criar um novo usuário
        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario = _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("CriarUsuario", usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível cadastrar seu usuário. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        // Action para alterar um usuário
        [HttpPost]
        public IActionResult Alterar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Busca o usuário existente no banco de dados
                    UsuarioModel usuario = _usuarioRepositorio.ListarPorId(usuarioSemSenhaModel.Id);

                    if (usuario == null)
                    {
                        TempData["MensagemErro"] = "Usuário não encontrado.";
                        return RedirectToAction("Index");
                    }

                    // Atualiza os campos herdados de PessoaModel e demais propriedades específicas de UsuarioModel
                    usuario.Nome = usuarioSemSenhaModel.Nome;
                    usuario.Login = usuarioSemSenhaModel.Login;
                    usuario.Email = usuarioSemSenhaModel.Email;
                    usuario.Perfil = usuarioSemSenhaModel.Perfil;

                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("EditarUsuario", usuarioSemSenhaModel);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível atualizar seu usuário. Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
