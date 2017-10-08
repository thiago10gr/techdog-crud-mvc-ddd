using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


using SimpleInjector;
using SimpleInjector.Integration.Web;
using System.Reflection;
using SimpleInjector.Integration.Web.Mvc;

using Projeto.Aplicacao.Contratos;
using Projeto.Aplicacao.Servicos;
using Projeto.Dominio.Contratos.Servicos;
using Projeto.Dominio.Servicos;
using Projeto.Dominio.Contratos.Repositorios;
using Projeto.Infra.Repositorio.Repositorios;
using Projeto.Dominio.Contratos.Utilitarios;
using Projeto.Infra.Util;

namespace Projeto.Apresentacao
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();



            // Register your types, for instance:
            container.Register<IUsuarioAplicacao, UsuarioAplicacao>(Lifestyle.Scoped);
            container.Register<IUsuarioServicoDominio, UsuarioServicoDominio>(Lifestyle.Scoped);
            container.Register<IUsuarioRepositorio, UsuarioRepositorio>(Lifestyle.Scoped);
            container.Register<ICriptografiaUtil, CriptografiaUtil>(Lifestyle.Scoped);



            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));




            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
