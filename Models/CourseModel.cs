﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDOPERATION.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Fees { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Status { get; set; }
    }
    public class CourseViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Course Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Fees")]
        public int Fees { get; set; }
        [Required]
        [DisplayName("Status")]
        public bool Status { get; set; }
    }
}