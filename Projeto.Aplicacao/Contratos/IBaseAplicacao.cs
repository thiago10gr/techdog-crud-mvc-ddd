using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Aplicacao.Contratos
{
    public interface IBaseAplicacao<TEntity, TKey> where TEntity : class
    {

        void Cadastrar(TEntity obj);

        void Atualizar(TEntity obj);

        void Excluir(TEntity obj);

        TEntity ObterPorId(TKey id);

        List<TEntity> ListarTodos();
    }
}
