using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjHosNav.Models;

namespace prjHosNav.Controllers
{
    public class MedicineController : Controller
    {
        
        public ActionResult myBoxSave()
        {
            if(Session[CDictionary.SK_LOGINED_USER] != null)
            {
                CMyMedicineBoxDetail x = new CMyMedicineBoxDetail();
                x.fChName = Request.Form["fChName"];
                x.fImagePath = Request.Form["fImagePath"];
                x.fDayOfUse = Request.Form["fDayOfUse"];
                x.fQuantityUse = Request.Form["fQuantityUse"];
                x.MId = (Session[CDictionary.SK_LOGINED_USER] as CMember).mId.ToString();
                (new CMyMedicineBoxFactory()).create(x);
                return RedirectToAction("myBox");
            }
            else
            {
                TempData["message"] = "尚未登入";
                return RedirectToAction("List", "Home");
            }                       
        }


        public ActionResult myBoxDelete(int id)
        {
            int userId = (Session[CDictionary.SK_LOGINED_USER] as CMember).mId;
            (new CMyMedicineBoxFactory()).delete(id,userId);
            return RedirectToAction("mybox");
        }
        public ActionResult myBoxEdit(int id)
        {
            CMyMedicineBoxDetail data = (new CMyMedicineBoxFactory()).queryById(id);
            if (data == null)
                return RedirectToAction("myBox");
            return View(data);
        }
        [HttpPost]
        public ActionResult myBoxEdit(CMyMedicineBoxDetail p)
        {
            p.MId =(Session[CDictionary.SK_LOGINED_USER] as CMember).mId.ToString();
            (new CMyMedicineBoxFactory()).update(p);
            return RedirectToAction("myBox");
        }

        public ActionResult myBoxCreate(int id)
        {
            if (Session[CDictionary.SK_LOGINED_USER] == null)
            {
                TempData["message"] = "尚未登入";
                return RedirectToAction("Index", "Home");
            }
            CMedicineDetail data = (new CMedicineFactory()).queryById(id);
            if (data == null)
                return RedirectToAction("List");
            return View(data);
           
        }

        public ActionResult myBox()
        {
            if (Session[CDictionary.SK_LOGINED_USER] == null)
            {
                TempData["message"] = "尚未登入";
                return RedirectToAction("Index", "Home");
            }
            int userId = (Session[CDictionary.SK_LOGINED_USER] as CMember).mId;
            List<CMyMedicineBoxDetail> data = null;            
            data = (new CMyMedicineBoxFactory()).queryByMId(userId);
            return View(data);
        }

        // GET: Medicine
        public ActionResult List()
        {
            List<CMedicineDetail> data = null;
            if (string.IsNullOrEmpty(Request.Form["txtKeyword"]))
                data = (new CMedicineFactory()).queryAll();
            else
                data = (new CMedicineFactory()).queryByKeyword(Request.Form["txtKeyword"]);
            string a = Request.Form["txtKeyword"];
            ViewBag.Ans = a;
            Console.WriteLine(data);
            return View(data);

        }

        public ActionResult ListAdmin()
        {
            List<CMedicineDetail> data = null;
            if (string.IsNullOrEmpty(Request.Form["txtKeyword"]))
                data = (new CMedicineFactory()).queryAll();
            else
                data = (new CMedicineFactory()).queryByKeyword(Request.Form["txtKeyword"]);
            return View(data);
        }


        public ActionResult Edit(int id)
        {
            CMedicineDetail data = (new CMedicineFactory()).queryById(id);
            if (data == null)
                return RedirectToAction("List");
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(CMedicineDetail p)
        {
            (new CMedicineFactory()).update(p);
            return RedirectToAction("ListAdmin");
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            (new CMedicineFactory()).delete(id);
            return RedirectToAction("ListAdmin");
        }

        [HttpPost]
        public ActionResult Save(HttpPostedFileBase fImagePath)
        {
            var fileName = fImagePath.FileName;
            var filePath = Server.MapPath("~/img/MImg/");
            //var filePath = Server.MapPath(string.Format("~/{0}", "File"));
            fImagePath.SaveAs(Path.Combine(filePath, fileName));

            CMedicineDetail x = new CMedicineDetail();
            x.fChName = Request.Form["fChName"];
            x.fEnName = Request.Form["fEnName"];
            x.fSymptoms = Request.Form["fSymptoms"];
            x.fCaution = Request.Form["fCaution"];
            x.fImagePath = fImagePath.FileName;

            (new CMedicineFactory()).create(x);
            return RedirectToAction("ListAdmin");
        }

    }
}