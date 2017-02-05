using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.DAO;
using BlogWeb.Models;
using BlogWeb.ViewModels;
using WebMatrix.WebData;
using BlogWeb.Filters;

namespace BlogWeb.Controllers
{
    
    public class LoginController : Controller
    {

        private UsuarioDAO usuarioDAO;

        public LoginController(UsuarioDAO usuarioDAO)
        {
            this.usuarioDAO = usuarioDAO;

            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection(
                    "blog", "Usuario", "Id", "Login", true);
            }
        }

        public ActionResult Autentica(LoginModel LoginModel, String Url)
        {
           
            if (ModelState.IsValid)
            {
                //Usuario usuario = usuarioDAO.BuscaUsuario(LoginModel);
                
                //if (usuario != null)
                if (WebSecurity.Login(LoginModel.Login, LoginModel.Senha))
                {
                    if (Url != null)
                    {
                        return RedirectToRoute(Url);
                    }
                    else { 
                            return RedirectToAction("Index", "Post");
                         }           
                    
                }
                else
                {
                    ModelState.AddModelError("Login.Invalido", "Login ou Senha Incorretos!");
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
        }
        
        // GET: Login
        
        public ActionResult Index()
        {
            return View();
        }

        [Route("Logout", Name = "Logout")]
        public ActionResult Logout()
        {
           
            WebSecurity.Logout();
            return RedirectToAction("Index");
        }


    }
}