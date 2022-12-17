using prjHosNav.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjHosNav.ViewModel;

namespace prjHosNav.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //門診後台管理
        COutpatientFactory COF = new COutpatientFactory();
        public ActionResult outpatient()
        {
            return View();
        }

        public JsonResult List()
        {
            return Json(COF.queryAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(COutpatient op)
        {
            return Json(COF.create(op), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(int id)
        {
            var Outpatient = COF.queryAll().Find(x => x.oid.Equals(id));
            return Json(Outpatient, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(COutpatient op)
        {
            return Json(COF.update(op), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            return Json(COF.delete(id), JsonRequestBehavior.AllowGet);
        }

        //症狀查詢後台管理
        CSearchFactory CSF = new CSearchFactory();
        public ActionResult Search()
        {
            return View();
        }

        public JsonResult SearchList()
        {
            return Json(CSF.queryAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchAdd(CSearch op)
        {
            return Json(CSF.create(op), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchGetById(int id)
        {
            var Outpatient = CSF.queryAll().Find(x => x.SId.Equals(id));
            return Json(Outpatient, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchUpdate(CSearch op)
        {
            return Json(CSF.update(op), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchDelete(int id)
        {
            return Json(CSF.delete(id), JsonRequestBehavior.AllowGet);
        }

        //會員登入系統
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session[CDictionary.SK_LOGINED_USER] = null;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(CLoginViewModel p)
        {
            CMember cust = new CMemberFactory().queryByEmail(p.txtEmail);
            if (cust != null && cust.mPassword.Equals(p.txtPassword))
            {
                Session[CDictionary.SK_LOGINED_USER] = cust;
                return RedirectToAction("Index");
            }
            TempData["message"] = "帳號密碼有誤，請重新登入";
            return RedirectToAction("Index");
        }

        public ActionResult 註冊成功()
        {
            return View();
        }

    }
}