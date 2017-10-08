using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Entidades;
using Projeto.Dominio.Contratos.Repositorios;

namespace Projeto.Infra.Repositorio.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario, int>, IUsuarioRepositorio
    {



        public bool EmailExistente(string email)
        {
            return contexto.Usuario
                .Where(u => u.Email.Equals(email)).Count() > 0;
        }


        public bool EmailExistente(string email, int idUsuario)
        {
            return contexto.Usuario
                .Where(u => u.Email.Equals(email) && u.IdUsuario != idUsuario).Count() > 0;
        }


        public Usuario ObterPorEmailSenha(string email, string senha)
        {
            return contexto.Usuario
                .FirstOrDefault(u => u.Email.Equals(email) && u.Senha.Equals(senha));
        }

    }
}
