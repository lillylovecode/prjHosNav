using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjHosNav.Models;
using prjHosNav.ViewModel;

namespace prjHosNav.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult 會員註冊()
        {
            return View();
        }

        public ActionResult MemberList()
        {
            var table = from m in new dbHospitalEntities1().tMember
                        select m;
            return View(table);
        }

        public ActionResult MemberCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MemberCreate(tMember m)
        {
            dbHospitalEntities1 db = new dbHospitalEntities1();
            db.tMember.Add(m);
            db.SaveChanges();
            return RedirectToAction("MemberList");
        }

        public ActionResult MemberDelete(int id)
        {
            dbHospitalEntities1 db = new dbHospitalEntities1();
            
            return RedirectToAction("MemberList");
        }

        [HttpPost]
        public ActionResult 會員註冊(CMemberViewModel p)
        {
            p.Authority = "使用者";
            CMember m = new CMember();
            bool isExit = new CMemberFactory().queryByEmailCheck(p.txtEmail);
            if (p != null)
            {
                if (isExit)
                {
                    ViewBag.message = "此信箱已被註冊";
                    return View();
                }
                else
                {
                    m.mName = p.txtName;
                    m.mEmail = p.txtEmail;
                    m.mPassword = p.txtPassword;
                    m.mPhone = p.txtPhone;
                    m.mGender = p.radioGender;
                    m.mAddress = p.selAddress;
                    m.mAuthority = p.Authority;
                    new CMemberFactory().create(m);
                    return RedirectToAction("註冊成功", "Home");
                }                
            }
            return RedirectToAction("Index", "Home");

            
        }

        public ActionResult 會員修改()
        {
            int id = (Session[CDictionary.SK_LOGINED_USER] as CMember).mId;
            CMember c = new CMemberFactory().queryById(id);
            return View(c);
        }

        [HttpPost]
        public ActionResult 會員修改(CMember c)
        {
            new CMemberFactory().update(c);
            TempData["message"] = "修改成功";
            return Redirect("~/Home/Index");
        }
    }
}