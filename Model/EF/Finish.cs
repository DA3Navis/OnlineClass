namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Finish")]
    public partial class Finish
    {
        public long ID { get; set; }

        public long UserID { get; set; }

        public long CourseID { get; set; }

        public long LessonID { get; set; }

        public bool? Done { get; set; }

        public virtual Course Course { get; set; }

        public virtual Lesson Lesson { get; set; }

        public virtual User User { get; set; }
    }
}
