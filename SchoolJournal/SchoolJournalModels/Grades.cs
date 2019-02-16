using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournalModels
{
    public class Grades
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GradeID { get; set; }
        public decimal Grade { get; set; }
        public Nullable<System.DateTime> DateOfGrade { get; set; }
        public string Observations { get; set; }

        public virtual GradeCategory GradeCategory { get; set; }
        public virtual Semesters Semesters { get; set; }
        public virtual Students Students { get; set; }
        public virtual Subjects Subjects { get; set; }
    }
}
