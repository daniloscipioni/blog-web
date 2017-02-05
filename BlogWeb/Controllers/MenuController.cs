using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.DAO;

namespace BlogWeb.Controllers
{
    public class MenuController : Controller
    {
        private PostDAO dao;
        private UsuarioDAO usuarioDAO;
        public MenuController(PostDAO dao, UsuarioDAO usuarioDAO)
        {
            this.dao = dao;
            this.usuarioDAO = usuarioDAO;
        }

        // GET: Menu
        public ActionResult Index()
        {
            ViewBag.PublicadosData = dao.PublicacoesPorMes();
            ViewBag.Autores = usuarioDAO.Lista();
            return PartialView(); //Não aplica o modelo _Layout por ser uma view Parcial
        }
    }
}