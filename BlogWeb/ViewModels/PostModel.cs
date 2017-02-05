using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BlogWeb.Models;


namespace BlogWeb.ViewModels
{
    public class PostModel
    {
        public int Id { get; set; }
        public string NomeAutor { get; set; }
        [StringLength(20)]
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public bool Publicado { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public int? AutorId { get; set; }
        public IList<int> Tags { get; set; }


    /*   public Post CriaPost()
        {
            Post post = new Post()
            {
                Id = this.Id,
                Titulo = this.Titulo,
                Conteudo = this.Conteudo,
                Publicado = this.Publicado,
                DataPublicacao = this.DataPublicacao
            };
            if (this.AutorId != null)
            {
                Usuario autor = new Usuario()
                {
                    Id = (int)this.AutorId
                };
                post.Autor = autor;
            }
            return post;
        }
  */
        public PostModel() { }

        public PostModel(Post post)
        {
            this.Id = post.Id;
            this.Titulo = post.Titulo;
            this.Conteudo = post.Conteudo;
            this.Publicado = post.Publicado;
            this.DataPublicacao = post.DataPublicacao;
            if (post.Autor != null)
            {
                this.AutorId = post.Autor.Id;
            }
            
        }
    }
}