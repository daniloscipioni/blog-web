using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogWeb.Models;
using FluentNHibernate.Mapping;

namespace BlogWeb.Mapeamentos
{
    public class UsuarioMapping: ClassMap<Usuario>
    {
        public UsuarioMapping()
        {
            Id(u => u.Id).GeneratedBy.Identity();
            Map(u => u.Nome);
            Map(u => u.Login);
            Map(u => u.Password);
            Map(u => u.Email);
        }
    }
}