using prjHosNav.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjHosNav.Controllers
{
    public class ExaminationController : Controller
    {
        // GET: Examination
        public ActionResult ExamList()
        {
            List<CExamination> exam = null;
            if (string.IsNullOrEmpty(Request.Form["txtKeyWord"]))
                exam = (new CExamFactory()).queryAll();
            else
                exam = (new CExamFactory()).queryByKeyword(Request.Form["txtKeyWord"]);
            return View(exam);
        }

        public ActionResult 查看注意事項(int id)
        {
            CExamination e = (new CExamFactory()).queryById(id);
            if (e == null)
                return RedirectToAction("ExamList");
            return View(e);
        }


    }
}