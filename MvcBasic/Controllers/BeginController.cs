using MvcBasic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBasic.Controllers
{
    public class BeginController : Controller
    {
        private MvcBasicContext db = new MvcBasicContext();

        // GET: Begin
        public ActionResult Index()
        {
            return Content("こんにちは世界");
            // return View();
        }

        public ActionResult Show()
        {
            ViewBag.Message = "埋め込みてすと";
            return View();
        }

        public ActionResult List()
        {
            return View(db.Members);
        }
    }
}