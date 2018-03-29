namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        public long ID { get; set; }

        [StringLength(250)]
        [Display(Name="Tên khóa học")]
        public string Name { get; set; }

        [StringLength(10)]
        [Display(Name = "Mã kích hoạt")]
        public string Code { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [Display(Name = "Giá")]
        public decimal? Price { get; set; }

        [Display(Name = "Giá khuyễn mãi")]
        public decimal? PromotonPrice { get; set; }

        [Display(Name = "Chủ đề")]
        public long? CategoryID { get; set; }


        [Column(TypeName = "ntext")]
        [Display(Name = "Mô tả")]
        public string Detail { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        [Display(Name = "Số lượt xem")]
        public int? ViewCount { get; set; }

        // Thêm
        public virtual CourseCategory Category { get; set; }
    }
}
