using prjHosNav.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjHosNav.ViewModel;

namespace prjHosNav.Controllers
{
    public class ReturnController : Controller
    {
        CReturnFactory CRF = new CReturnFactory();
        // GET: Return
        public ActionResult Return()
        {
            if (Session[CDictionary.SK_LOGINED_USER] == null)
            {
                TempData["message"] = "尚未登入";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public JsonResult List()
        {
            return Json(CRF.queryAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(CReturn op)
        {
            return Json(CRF.create(op), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(int id)
        {
            var HosReturn = CRF.queryAll().Find(x => x.RId.Equals(id));
            return Json(HosReturn, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByMId(int id)
        {
            var HosReturn = new CReturnFactory().queryByMId(id);
            return Json(HosReturn, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(CReturn op)
        {
            return Json(CRF.update(op), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            return Json(CRF.delete(id), JsonRequestBehavior.AllowGet);
        }
    }
}