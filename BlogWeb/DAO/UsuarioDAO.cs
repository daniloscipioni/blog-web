using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogWeb.Models;
using BlogWeb.ViewModels;
using BlogWeb.Infra;
using NHibernate;
using WebMatrix.WebData;

namespace BlogWeb.DAO
{
    public class UsuarioDAO
    {
        private ISession session;

        public UsuarioDAO(ISession session)
        {
            this.session = session;
        }
        public IList<Usuario> Lista()
        {
            //using (ISession session = NHibernateHelper.AbreSession())
            //{
                string hql = "select u from Usuario u";
                IQuery query = session.CreateQuery(hql);
                return query.List<Usuario>();
            //}

        }
        public void Adiciona(Usuario usuario)
        {
            //using (ISession session = NHibernateHelper.AbreSession())
            //{
                ITransaction tx = session.BeginTransaction();
                session.Save(usuario);
                tx.Commit();
            //}
        }
        public Usuario BuscaID(int id)
        {
            //using (ISession session = NHibernateHelper.AbreSession())
            //{
                return session.Get<Usuario>(id);
            //}
        }

        public void Remove(Usuario usuario)
        {
            //using (ISession session = NHibernateHelper.AbreSession())
            //{
                ITransaction tx = session.BeginTransaction();
                session.Delete(usuario);
                tx.Commit();

            

            //}
        }

        public void Atualiza(Usuario usuario)
        {
            //using (ISession session = NHibernateHelper.AbreSession())
            //{
                ITransaction tx = session.BeginTransaction();
                session.Merge(usuario);
                tx.Commit();
            //}
        }

        public Usuario BuscaUsuario(LoginModel LoginModel)
        {
            string hql = "select u from Usuario u where " +
                         "u.Login = :login and u.Password = :senha";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("login", LoginModel.Login);
            query.SetParameter("senha",LoginModel.Senha);
            return query.UniqueResult<Usuario>();// retorna somente um resultado
        }

    }
}