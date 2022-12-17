using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjHosNav.Models
{
    public class CMember
    {
        public int mId { get; set; }
        public string mName { get; set; }
        public string mEmail { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "密碼不可空白")]
        public string mPassword { get; set; }

        [Compare("mPassword", ErrorMessage = "兩組密碼必須相同")]
        public string mPwdCheck { get; set; }

        public string mPhone { get; set; }
        public string mGender { get; set; }
        public string mAddress { get; set; }
        public string mAuthority { get; set; }
    }

    public enum Address
    {
        高雄市,
        台南市,
        台中市,
        新北市,
        台北市
    }
}