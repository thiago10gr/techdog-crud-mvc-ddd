using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Entidades;
using Projeto.Dominio.Contratos;

namespace Projeto.Dominio.Contratos.Repositorios
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario, int>
    {
        Usuario ObterPorEmailSenha(string email, string senha);

        bool EmailExistente(string email);

        bool EmailExistente(string email, int idUsuario);
    }
}
