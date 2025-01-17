﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService.IFacultyService.Dto
{
    public class FacultyByIdDto
    {
        public int FacultyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentID { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
