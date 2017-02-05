using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using BlogWeb.DAO;
using BlogWeb.Models;
using BlogWeb.ViewModels;

namespace BlogWeb.Controllers
{
    public class BuscaController : Controller
    {
        // GET: Busca
             
        private PostDAO dao;
        private UsuarioDAO usuarioDAO;
        public BuscaController(PostDAO dao, UsuarioDAO usuarioDAO)
        {
            this.dao = dao;
            this.usuarioDAO = usuarioDAO;
        }
        

        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]    
        [Route("Busca/Autor/{NomeEmail}")]
        public ActionResult BuscaPorAutor(string NomeEmail)
        {
            IList<Post> resultado = dao.ListaPublicacoesDoAutor(NomeEmail);
            return View(resultado);
        }
        [Route("Busca/Mes/{Mes}/Ano/{Ano}")]
        public ActionResult BuscaPorMes(int Mes, int Ano)
        {
            IList<Post> resultado = dao.ListaPublicadosPorMes(Mes, Ano);
            return View(resultado);
        } 
    }
}