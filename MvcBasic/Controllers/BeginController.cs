using MvcBasic.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
            IEnumerable<MvcBasic.Models.Member> model = null;
            model = db.Members;
            try
            {
                Debug.Print("hoge = " + model.ToString());
            }
            catch (SqlException ex)
            {
                foreach (var k in ex.Data.Keys)
                {
                    var v = ex.Data[k];
                    Debug.Print(k + " = " + v);
                }
                Debug.Print("---");
            }
            return View(db.Members);
        }
    }
}