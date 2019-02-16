﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournalModels
{
    public class Homework
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int HomeworkID { get; set; }
        public Nullable<System.DateTime> DateOfHomework { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public string Details { get; set; }

        public virtual Students Students { get; set; }
        public virtual Subjects Subjects { get; set; }
    }
}
