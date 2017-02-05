using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogWeb.Models;
using NHibernate;
using BlogWeb.Infra;
using System.Web.Mvc;
using NHibernate.Transform;

namespace BlogWeb.DAO
{
    
    public class PostDAO
    {
        private ISession session;

        public PostDAO(ISession session)
        {
            this.session = session;
        }
        public IList<Post> Lista()
        {
            //using (ISession session = NHibernateHelper.AbreSession())
            //{
                string hql = "select p from Post p";
                IQuery query = session.CreateQuery(hql);
                return query.List<Post>();
            //}

        }
        public IList<Post> ListaPublicados()
        {
            //using (ISession session = NHibernateHelper.AbreSession())
            //{
            string hql = "select p from Post p where p.Publicado = true order by DataPublicacao Desc";
            IQuery query = session.CreateQuery(hql);
            return query.List<Post>();
            //}
        }
 
        public IList<Post> ListaPublicacoesDoAutor(string AutorEmail)
        {
            //using (ISession session = NHibernateHelper.AbreSession())
            //{
            string hql = "select p from Post p join p.Autor a where p.Publicado = true and a.Nome = :Autor or a.Email = :Email";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("Autor", AutorEmail);
            query.SetParameter("Email", AutorEmail);
            return query.List<Post>();
            //}
        }

        public IList<Post> ListaPublicadosPorMes(int Mes, int Ano)
        {
            string hql = "select p from Post p where p.Publicado = true and year(p.DataPublicacao) = :Ano and month(p.DataPublicacao) = :Mes";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("Ano", Ano);
            query.SetParameter("Mes", Mes);
            return query.List<Post>();
        }

        public void Adiciona(Post post)
        {
           // using (ISession session = NHibernateHelper.AbreSession())
            //{
                ITransaction tx = session.BeginTransaction();
                session.Save(post);
                tx.Commit();
           // }
        }

        public Post BuscaID(int id)
        {
            //using (ISession session = NHibernateHelper.AbreSession())
           // {
                return session.Get<Post>(id);
           // }
        }

        public void Remove(Post post)
        {
           // using (ISession session = NHibernateHelper.AbreSession())
           // {
                ITransaction tx = session.BeginTransaction();
                session.Delete(post);
                tx.Commit();
           // }
        }

        public void Atualiza(Post post)
        {
            //using (ISession session = NHibernateHelper.AbreSession())
            //{
                ITransaction tx = session.BeginTransaction();
                session.Merge(post);
                tx.Commit();
           //}
        }

        public IList<PostsPorMes> PublicacoesPorMes()
        {
            string hql = "select month(p.DataPublicacao) as Mes, " +
                                 "year(p.DataPublicacao) as Ano, " +
                                 "count(p) as Quantidade " +
                                 "from Post p " +
                                 "where p.Publicado = true " +
                                 "group by month(p.DataPublicacao), year(p.DataPublicacao)" +
                                 "Order by month(p.DataPublicacao), year(p.DataPublicacao) Desc";
            IQuery query = session.CreateQuery(hql);
            query.SetResultTransformer(Transformers.AliasToBean<PostsPorMes>());
            IList<PostsPorMes> resultado = query.List<PostsPorMes>();

            return resultado;
        }

       

    }
}