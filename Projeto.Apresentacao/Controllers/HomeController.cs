using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Projeto.Apresentacao.Models;
using Projeto.Aplicacao.Contratos;
using Projeto.Entidades;
using System.Web.Security;

namespace Projeto.Apresentacao.Controllers
{
    public class HomeController : Controller
    {


        private readonly IUsuarioAplicacao appUsuario;



        public HomeController(IUsuarioAplicacao appUsuario) 
        {
            this.appUsuario = appUsuario;
        }



        [HttpPost]
        public ActionResult Login(HomeViewModelLogin model)
        {
            if(ModelState.IsValid)
            {
                try
                {

                    Usuario u = appUsuario.Autenticar(model.EmailAcesso, model.SenhaAcesso);


                    //ticket de acesso do usuario 
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(u.IdUsuario.ToString(), false, 5);

                    //criando um cookie para gravar o tiket do usuario
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));


                    Response.Cookies.Add(cookie);

                    Session.Add("usuario", u);


                    return RedirectToAction("Index", "Usuario", new { area = "AreaRestrita" });


                } catch (Exception e)
                {
                    ViewBag.MsgErro = e.Message;
                }
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(HomeViewModelCadastro model)
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


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            Session.Remove("usuario");
        
            return RedirectToAction("Login", "Home", new { area = "" });

        }
    }

   
}