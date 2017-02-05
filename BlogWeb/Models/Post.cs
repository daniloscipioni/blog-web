using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogWeb.Models
{
    public class Post
    {
        public virtual int Id { get; set; }
        [StringLength(10)]
        public virtual string NomeAutor { get; set; }

        [StringLength(20)]
        public virtual string Titulo { get; set; }
        [StringLength(100)]
        public virtual string Conteudo { get; set; }

        public virtual DateTime? DataPublicacao { get; set; }

        public virtual bool Publicado { get; set; }

        public virtual Usuario Autor { get; set; }

        public virtual IList<Tag> Tags { get; set; }
    }
}