using BlogWeb.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogWeb.Models;

namespace BlogWeb.Controllers
{
    public class TagController : Controller
    {
        // GET: Tag
        private TagDAO dao;

        public TagController(TagDAO dao)
        {
            this.dao = dao;
        }
        public ActionResult Index()
        {
            IList<Tag> tags = dao.Lista();
            return View(tags);
        }

        public ActionResult Adiciona(Tag tag)
        {
            dao.Adiciona(tag);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            Tag tag = dao.BuscaId(id);
            dao.Remove(tag);
            return RedirectToAction("Index");
        }

        public ActionResult InsereTag()
        {
            return View();
        }


    }
}