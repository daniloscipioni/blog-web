using BlogWeb.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogWeb.Mapeamentos
{
    public class PostMapping : ClassMap<Post>
    {
        public PostMapping()
        {
            //Posso colocar o nome da tabela no formato: Table("NOME_TABELA")
            //Table("teste");
            Id(post => post.Id).GeneratedBy.Identity();
            Map(post => post.Titulo);
            Map(post => post.NomeAutor);
            Map(post => post.Conteudo);
            Map(post => post.DataPublicacao);
            Map(post => post.Publicado);

            References(p => p.Autor, "AutorId");

            HasManyToMany(p => p.Tags)
                .Table("Post_Tags")
                .ParentKeyColumn("PostId")
                .ChildKeyColumn("TagId");
        }
    }
}