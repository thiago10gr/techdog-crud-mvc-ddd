﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Projeto.Dominio.Contratos.Servicos;
using Projeto.Dominio.Contratos.Repositorios;

namespace Projeto.Dominio.Servicos
{
    public class BaseServicoDominio<TEntity, TKey> 
        : IBaseServicoDominio<TEntity, TKey> where TEntity : class
    {


        private readonly IBaseRepositorio<TEntity, TKey> repositorio;


        public BaseServicoDominio(IBaseRepositorio<TEntity, TKey> repositorio)
        {
            this.repositorio = repositorio;
        }



        public virtual void Cadastrar(TEntity obj)
        {
            try
            {
                repositorio.BeginTransaction();
                repositorio.Inserir(obj);
                repositorio.Commit();
            } catch(Exception ex)
            {
                repositorio.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public virtual void Atualizar(TEntity obj)
        {
            try
            {
                repositorio.BeginTransaction();
                repositorio.Atualizar(obj);
                repositorio.Commit();
            }
            catch (Exception ex)
            {
                repositorio.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public virtual void Excluir(TEntity obj)
        {
            try
            {
                repositorio.BeginTransaction();
                repositorio.Excluir(obj);
                repositorio.Commit();
            }
            catch (Exception ex)
            {
                repositorio.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public virtual TEntity ObterPorId(TKey id)
        {
            try
            {
                return repositorio.ObterPorId(id);
            }
            catch (Exception ex)
            {
                repositorio.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public virtual List<TEntity> ListarTodos()
        {
            try
            {
                return repositorio.ListarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       

    }
}
