using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.DAO;
using BlogWeb.Models;
using BlogWeb.ViewModels;
using BlogWeb.Filters;
using AutoMapper;

namespace BlogWeb.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private PostDAO dao;
        private UsuarioDAO usuarioDAO;
        private TagDAO tagDAO;

        public PostController(PostDAO dao, UsuarioDAO usuarioDAO, TagDAO tagDAO)
        {
            this.dao = dao;
            this.usuarioDAO = usuarioDAO;
            this.tagDAO = tagDAO;
        }
        
        // GET: Post
        [Route("posts", Name = "/posts")]
        public ActionResult Index()
        {
            //ViewBag.Posts = dao.Lista();
            IList<Post> posts = dao.Lista();
            return View(posts);
        }

        public ActionResult InserePost()
        {
            //ViewBag.Post = new Post();//Essa linha é para os campos do formulário não começarem como campos indefinidos;
            ViewBag.Usuarios = usuarioDAO.Lista();
            ViewBag.ListaTags = tagDAO.Lista();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adiciona(PostModel viewModel)
        {
            if (viewModel.Publicado && !viewModel.DataPublicacao.HasValue)
            {
                ModelState.AddModelError("post.invalido", "Todo Post publicado deve haver uma data de publicação!");
            }

            if (ModelState.IsValid)
            {
               // Post post = viewModel.CriaPost();
                Post post = Mapper.Map<Post>(viewModel);
                dao.Adiciona(post);
                return RedirectToAction("Index");
            }
            else
            {
                //ViewBag.Post = post;
                /* Código para caso queira passar os dados para a View por ViewData e não por ViewBag
                ViewData["titulo"] = post.Titulo;
                ViewData["NomeAutor"] = post.NomeAutor;
                ViewData["Conteudo"] = post.Conteudo;
                ViewData["DataPublicacao"] = post.DataPublicacao;
                ViewData["Publicado"] = post.Publicado;
                */

                ViewBag.Usuarios = usuarioDAO.Lista();
                ViewBag.ListaTags = tagDAO.Lista();
                return View("InserePost", viewModel);
            }
        }
        public ActionResult Remove(int id)
        {
            Post post = dao.BuscaID(id);
            dao.Remove(post);

            return RedirectToAction("Index");
        }

        [Route("posts/{id}", Name = "VisualizaPost")]
        public ActionResult Visualiza(int id)
        {
            ViewBag.ListaTags = tagDAO.Lista();
            Post post = dao.BuscaID(id);
            //PostModel viewModel = new PostModel(post);
            PostModel viewModel = Mapper.Map<PostModel>(post);
            ViewBag.Usuarios = usuarioDAO.Lista();
            
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Altera(PostModel viewModel)
        {
            if (viewModel.Publicado && !viewModel.DataPublicacao.HasValue)
            {
                ModelState.AddModelError("post.invalido", "Todo Post publicado deve haver uma data de publicação!");
            }

            if (ModelState.IsValid)
            {
                //Post post = viewModel.CriaPost();
                Post post = Mapper.Map<Post>(viewModel);
                dao.Atualiza(post);
                return RedirectToAction("Index", "Post");
            }
            else
            {
                ViewBag.ListaTags = tagDAO.Lista();
                ViewBag.Usuarios = usuarioDAO.Lista();

                return View("Visualiza", viewModel);
            }

        }
        [Route("Estatisticas", Name = "/Estatisticas")]
        public ActionResult Estatisticas()
        {
            IList<PostsPorMes> postMES = dao.PublicacoesPorMes();
            ViewBag.PublicadosData = dao.Lista();
            return View(postMES);
        }

       public ActionResult Publica(int Id)
       {
        Post post = dao.BuscaID(Id);
        post.Publicado = true;
        post.DataPublicacao = DateTime.Now;
        dao.Atualiza(post);
        return new EmptyResult();
       }
     }
}