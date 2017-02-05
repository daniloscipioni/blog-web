using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogWeb.Models;

namespace BlogWeb.DAO
{
    public class TagDAO
    {
        private ISession session;

        public TagDAO(ISession session)
        {
            this.session = session;
        }

        public IList<Tag> Lista()
        {
            string hql = "select t from Tag t";
            IQuery query = session.CreateQuery(hql);
            return query.List<Tag>();
        }
    
        public void Adiciona(Tag tag)
        {
            ITransaction tx = session.BeginTransaction();
            session.Save(tag);
            tx.Commit();
        }

        public void Remove(Tag tag)
        {
            ITransaction tx = session.BeginTransaction();
            session.Delete(tag);
            tx.Commit();
        }

        public Tag BuscaId(int id)
        {
            return session.Get<Tag>(id);
        }


    }
}