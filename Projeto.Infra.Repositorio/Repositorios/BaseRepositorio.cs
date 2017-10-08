using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Projeto.Dominio.Contratos.Repositorios;
using Projeto.Infra.Repositorio.Configuracoes;
using System.Data.Entity;

namespace Projeto.Infra.Repositorio.Repositorios
{
    public abstract class BaseRepositorio<TEntity, TKey> 
        : IBaseRepositorio<TEntity, TKey> where TEntity : class
    {


        protected readonly DataContext contexto;
        private DbContextTransaction transaction;


        public BaseRepositorio()
        {
            contexto = new DataContext();
        }



        public void Inserir(TEntity obj)
        {
            contexto.Entry(obj).State = EntityState.Added;
            contexto.SaveChanges();
        }


        public void Atualizar(TEntity obj)
        {
            contexto.Entry(obj).State = EntityState.Modified;
            contexto.SaveChanges();
        }


        public void Excluir(TEntity obj)
        {
            contexto.Entry(obj).State = EntityState.Deleted;
            contexto.SaveChanges();
        }


        public TEntity ObterPorId(TKey id)
        {
            return contexto.Set<TEntity>().Find(id);
        }


        public List<TEntity> ListarTodos()
        {
            return contexto.Set<TEntity>().ToList();
        }

        public void BeginTransaction()
        {
            transaction = contexto.Database.BeginTransaction();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

       
    }
}
