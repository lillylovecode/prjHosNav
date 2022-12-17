using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjHosNav.Models
{
    public class CMedicineDetail
    {
        public int fId { get; set; }
        public string fChName { get; set; }
        public string fEnName { get; set; }
        public string fSymptoms { get; set; }
        public string fCaution { get; set; }
        public string fImagePath { get; set; }
        public string MId { get; set; }
    }
}