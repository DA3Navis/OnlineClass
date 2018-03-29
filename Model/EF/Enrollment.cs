namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Enrollment")]
    public partial class Enrollment
    {
        public long ID { get; set; }

        public long CourseID { get; set; }

        public long UserID { get; set; }

        public double? Advance { get; set; }
    }
}
