namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lesson")]
    public partial class Lesson
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lesson()
        {
            Finishes = new HashSet<Finish>();
        }

        public long ID { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public long CourseID { get; set; }

        [StringLength(250)]
        [Display(Name = "Link Nhúng")]
        public string LinkURL { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(250)]
        [Display(Name = "Link Chia sẻ")]
        public string YoutubeID { get; set; }

        public virtual Course Course { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Finish> Finishes { get; set; }
    }
}
