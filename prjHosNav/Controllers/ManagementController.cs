using prjHosNav.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjHosNav.Controllers
{
    public class ManagementController : Controller
    {
        // GET: Management
        public ActionResult ManageList()
        { //移至後台管理介面
            return View();
        }
    }

}