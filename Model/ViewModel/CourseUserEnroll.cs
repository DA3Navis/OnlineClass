using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class CourseUserEnroll
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
        public decimal? PromotonPrice { get; set; }
        public long CategoryID { get; set; }
        public int? CountLesson { get; set; }
        public long UserID { get; set; }
        public double? Advance { get; set; }
    }
}
