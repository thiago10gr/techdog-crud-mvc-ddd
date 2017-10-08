using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Dominio.Contratos.Repositorios;
using Projeto.Entidades;
using Projeto.Dominio.Contratos.Servicos;
using Projeto.Dominio.Contratos.Utilitarios;
using Projeto.Dominio.Excecoes;
using Projeto.Entidades.Tipos;

namespace Projeto.Dominio.Servicos
{
    public class UsuarioServicoDominio
        : BaseServicoDominio<Usuario, int>, IUsuarioServicoDominio
    {


        private readonly IUsuarioRepositorio repositorio;
        private readonly ICriptografiaUtil criptografia;


        public UsuarioServicoDominio(IUsuarioRepositorio repositorio, ICriptografiaUtil criptografia)
            : base(repositorio)
        {
            this.repositorio = repositorio;
            this.criptografia = criptografia;
        }

        public Usuario Autenticar(string email, string senha)
        {

            senha = criptografia.EncriptarSenha(senha);


            Usuario u = repositorio.ObterPorEmailSenha(email, senha);


            if (u != null && u.Ativo.Equals(SimNao.Sim))
            {
                return u;
            }
            else
            {
                throw new CustomException("Acesso Negado. Tente novamente.");
            }
        }



        public override void Cadastrar(Usuario obj)
        {
            if (!repositorio.EmailExistente(obj.Email))
            {

                obj.Senha = criptografia.EncriptarSenha(obj.Senha);
                obj.DataCadastro = DateTime.Now;
                obj.Ativo = SimNao.Sim;

                base.Cadastrar(obj);
            }
            else
            {
                throw new CustomException("Já existe um cadastro com este e-mail.");
            }
        }

        public override void Atualizar(Usuario obj)
        {
            if (!repositorio.EmailExistente(obj.Email, obj.IdUsuario))
            {

                obj.Senha = criptografia.EncriptarSenha(obj.Senha);

                base.Atualizar(obj);
            }
            else
            {
                throw new CustomException("Já existe um cadastro com este e-mail.");
            }
        }
    }
}
