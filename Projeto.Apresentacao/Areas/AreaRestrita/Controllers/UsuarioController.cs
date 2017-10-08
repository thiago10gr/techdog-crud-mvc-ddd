using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Projeto.Aplicacao.Servicos;
using Projeto.Entidades;
using Projeto.Apresentacao.Areas.AreaRestrita.Models;
using Projeto.Aplicacao.Contratos;

namespace Projeto.Apresentacao.Areas.AreaRestrita.Controllers
{
    public class UsuarioController : Controller
    {


        private readonly IUsuarioAplicacao appUsuario;


        public UsuarioController(IUsuarioAplicacao appUsuario)
        {
            this.appUsuario = appUsuario;
        }


        // GET: AreaRestrita/Usuario
        [Authorize] 
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost, Authorize]
        public ActionResult Cadastro(UsuarioViewModelCadastro model)
        {
                if (ModelState.IsValid)
                {
                    try
                    {

                        Usuario u = new Usuario()
                        {
                            Nome = model.Nome,
                            Email = model.Email,
                            Senha = model.Senha,
                        };

                        appUsuario.Cadastrar(u);

                        ViewBag.MsgSucesso = "Cadastro realizado com sucesso.";

                        ModelState.Clear();

                    }
                    catch (Exception e)
                    {
                        ViewBag.MsgErro = e.Message;
                    }
                }

                return View();
            }




        public UsuarioViewModelEdicao MontarUsuario(int id)
        {
            Usuario u = appUsuario.ObterPorId(id);

            UsuarioViewModelEdicao model = new UsuarioViewModelEdicao()
            {
                IdUsuario = u.IdUsuario,
                Nome = u.Nome,
                Email = u.Email,
                DataCadastro = u.DataCadastro,
                Ativo = u.Ativo
            };

            return model;
        }




        [Authorize]
        public ActionResult Edicao(int id)
        {
            return View(MontarUsuario(id));
        }


        [HttpPost, Authorize]
        public ActionResult Edicao(UsuarioViewModelEdicao model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Usuario u = appUsuario.ObterPorId(model.IdUsuario);

                    u.Nome = model.Nome;
                    u.Email = model.Email;
                    u.Senha = model.Senha;
                    u.Ativo = model.Ativo;

                    appUsuario.Atualizar(u);

                    ModelState.Clear();

                    ViewBag.MsgSucesso = "Cadastro atualizado com sucesso.";

                }
                catch (Exception e)
                {
                    ViewBag.MsgErro = e.Message;
                }
            }

            return View(MontarUsuario(model.IdUsuario));
        }


        [Authorize]
        public ActionResult Exclusao(int id)
        {
            Usuario u = appUsuario.ObterPorId(id);

            UsuarioViewModelExclusao model = new UsuarioViewModelExclusao()
            {
                IdUsuario = u.IdUsuario,
                Nome = u.Nome,
                Email = u.Email,
                DataCadastro = u.DataCadastro,
                Ativo = u.Ativo
            };

            return View(model);
        }


        [HttpPost, Authorize]
        public ActionResult Exclusao(UsuarioViewModelExclusao model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Usuario u = appUsuario.ObterPorId(model.IdUsuario);

                    appUsuario.Excluir(u);

                    TempData["MsgSucesso"] = "Cadastro excluido com sucesso.";

                }
                catch (Exception e)
                {
                    TempData["MsgErro"] = e.Message;
                }
            }

            return RedirectToAction("Consulta");
        }

        [Authorize]
        public ActionResult Consulta()
        {
            List<UsuarioViewModelConsulta> lista = new List<UsuarioViewModelConsulta>();

            foreach(Usuario u in appUsuario.ListarTodos())
            {
                lista.Add(new UsuarioViewModelConsulta()
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Ativo = u.Ativo,
                    DataCadastro = u.DataCadastro,
                    Email = u.Email,
                    Senha = u.Senha
                });
            }
            
            return View(lista);
        }
    }
}