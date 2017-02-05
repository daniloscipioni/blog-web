using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.Models;
using BlogWeb.DAO;
using WebMatrix.WebData;
using System.Web.Security;

namespace BlogWeb.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private PostDAO dao;
        private UsuarioDAO usuarioDAO;

        public UsuarioController(PostDAO dao, UsuarioDAO usuarioDAO)
        {
            this.dao = dao;
            this.usuarioDAO = usuarioDAO;
            
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection(
                    "blog", "Usuario", "Id", "Login", true);
            }
        }
        

        // GET: Usuario
        [Route("NovoUsuario", Name = "NovoUsuario")]
        public ActionResult Form()
        {
            return View();
        }
        
        public ActionResult Adiciona(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                try{
                //usuarioDAO.Adiciona(usuario);
                //Grava o novo usuário no banco de dados
                WebSecurity.CreateUserAndAccount(usuario.Login, usuario.Password,
                    new { Email = usuario.Email, Nome = usuario.Nome }, false);
                return RedirectToAction("Index");
                }
                catch (MembershipCreateUserException e)
                {
                    //Se o usuário já existir, mostra um erro de validação
                    ModelState.AddModelError("usuario.Invalido", e.Message);
                    return View("Form");
                }
            
            }
            else
            {
                
                return View("Form", usuario);
            }
        }

        
        [Route("usuarios", Name = "/usuarios")]
        public ActionResult Index()
        {
            IList<Usuario> usuarios = usuarioDAO.Lista();
            return View(usuarios);
        }

        public ActionResult Remove(int id)
        {
            Usuario usuario = usuarioDAO.BuscaID(id);
            usuarioDAO.Remove(usuario);

            return RedirectToAction("Index");
        }
        
        [Route("usuarios/{id}", Name = "VisualizaUsuario")]
        public ActionResult Visualiza(int id)
        {
            Usuario usuario = usuarioDAO.BuscaID(id);
            return View("Visualiza", usuario);
        }
        
        public ActionResult Altera(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuarioDAO.Atualiza(usuario);
                return RedirectToAction("Index", "Usuario");
            }
            else
            {
                return View("Visualiza", usuario);
            }
        }
    }
}