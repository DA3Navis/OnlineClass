using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineClass2.Models
{
    [Serializable]
    public class Enrollment
    {
        public Course Course { get; set; }
        public long UserID { get; set; }
        //public float Advance { get; set; }
    }
}