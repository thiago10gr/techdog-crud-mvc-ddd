using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Aplicacao.Contratos;
using Projeto.Dominio.Contratos.Servicos;

namespace Projeto.Aplicacao.Servicos
{
    public class BaseAplicacao<TEntity, TKey> : IBaseAplicacao<TEntity, TKey> where TEntity : class
    {


        private readonly IBaseServicoDominio<TEntity, TKey> dominio;


        public BaseAplicacao(IBaseServicoDominio<TEntity, TKey> dominio) 
        {
            this.dominio = dominio;
        }


        public void Cadastrar(TEntity obj)
        {
            dominio.Cadastrar(obj);
        }


        public void Atualizar(TEntity obj)
        {
            dominio.Atualizar(obj);
        }


        public void Excluir(TEntity obj)
        {
            dominio.Excluir(obj);
        }


        public TEntity ObterPorId(TKey id)
        {
            return dominio.ObterPorId(id);
        }


        public List<TEntity> ListarTodos()
        {
            return dominio.ListarTodos();
        }

    }
}
