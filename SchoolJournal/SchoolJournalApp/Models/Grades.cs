//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolJournalApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Grades
    {
        public int GradeID { get; set; }
        public int StudentID { get; set; }
        public int SemesterID { get; set; }
        public int SubjectID { get; set; }
        public int CategoryID { get; set; }
        public decimal Grade { get; set; }
        public Nullable<System.DateTime> DateOfGrade { get; set; }
        public string Observations { get; set; }
    
        public virtual GradeCategory GradeCategory { get; set; }
        public virtual Semesters Semesters { get; set; }
        public virtual Students Students { get; set; }
        public virtual Subjects Subjects { get; set; }
    }
}
