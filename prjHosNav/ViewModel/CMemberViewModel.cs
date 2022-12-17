using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjHosNav.ViewModel
{
    public class CMemberViewModel
    {
        public int txtId { get; set; }

        [DisplayName("姓名")]
        [Required(ErrorMessage = "姓名不可空白")]
        public string txtName { get; set; }

        [DisplayName("信箱")]
        [Required(ErrorMessage = "信箱不可空白")]
        [EmailAddress(ErrorMessage = "Email格式有誤")]
        public string txtEmail { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "密碼不可空白")]
        public string txtPassword { get; set; }

        [Compare("txtPassword", ErrorMessage = "兩組密碼必須相同")]
        public string txtPwdCheck { get; set; }
        


        [DisplayName("電話")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "請輸入09開頭之號碼")] 
        [Required(ErrorMessage = "電話不可空白")]
        public string txtPhone { get; set; }

        [DisplayName("性別")]
        [Required(ErrorMessage = "請選擇性別")]
        public string radioGender { get; set; }

        [DisplayName("地址")]
        [Required(ErrorMessage = "請選擇居住地")]
        public string selAddress { get; set; }

        public string Authority { get; set; }
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