using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjHosNav.Models;

namespace prjHosNav.Controllers 
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult List()
        {
            List<CSearch> data = null;
            if (string.IsNullOrEmpty(Request.Form["txtKeyword"]))
                data = (new CSearchFactory()).queryAll();
            else
            {
                data = (new CSearchFactory()).queryByKeyword(Request.Form["txtKeyword"]);
                string a = Request.Form["txtKeyword"];
                ViewBag.Ans = a;
                Console.WriteLine(data);
            }
            return View(data);
        }

        public ActionResult Search2()
        {
            return View();
        }

    }
}