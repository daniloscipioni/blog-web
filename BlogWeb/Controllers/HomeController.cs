using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.DAO;
using BlogWeb.Models;
using BlogWeb.Filters;

namespace BlogWeb.Controllers
{
  
    public class HomeController : Controller
    {
        // GET: Home

        private PostDAO dao;
        private UsuarioDAO usuarioDAO;

        public HomeController(PostDAO dao, UsuarioDAO usuarioDAO)
        {
            this.dao = dao;
            this.usuarioDAO = usuarioDAO;
        }

   
        public ActionResult Index()
        {
            IList<Post> posts = dao.ListaPublicados();
            return View(posts);
        }
    }
}