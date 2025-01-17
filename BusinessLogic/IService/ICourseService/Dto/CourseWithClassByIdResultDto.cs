﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.ICourseService.Dto
{
    public class CourseWithClassByIdResultDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public DateTime StartRegisterDate { get; set; }
        public DateTime EndRegisterDate { get; set; }
        public int MaxAmountRegist { get; set; }
        public string FacultyName { get; set; }
        public string ClassName { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }
    }
}
