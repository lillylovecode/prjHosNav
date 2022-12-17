using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjHosNav.Models;

namespace prjHosNav.Controllers
{
    public class OutpatientController : Controller
    {
        // GET: Outpatient
        public ActionResult List()
        {
            List<CHospital> data = new CHospitalFactory().queryAll();
            return View(data);
        }

        public ActionResult 診間(string id)
        {
            List<COutpatient> o = (new COutpatientFactory()).queryByhId(id);
            return View(o);
        }

        public ActionResult location(int id)
        {
            return View();
        }
    }
}