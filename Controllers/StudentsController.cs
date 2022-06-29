using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using APIDEMO01.Models;
using APIDEMO01.SQL;
using APIDEMO01.SQL.Tables;
//using APIDEMO01.Dtos;


namespace APIDEMO01.Controllers{

    [ApiController]
    [Route("students")]
    public class StudentsController {
        private readonly IStudentData studentData;

        public StudentsController(IStudentData studentData) {
            this.studentData = studentData;
        }

        [HttpGet]
        public Task<List<StudentModel>> getStudents() {
            var students = studentData.GetStudents();
            return students;
        }
    }
}