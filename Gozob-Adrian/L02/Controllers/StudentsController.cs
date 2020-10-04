using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace L02.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public Student Get(int id)
        {
            foreach (Student student in StudentRepo.list)
            {
                if (student.Id == id)
                    return student;
            }
            return null;
        }

        [HttpDelete("{id}")]
        public List<Student> Delete(int id)
        {
            foreach (Student student in StudentRepo.list)
            {
                if (student.Id == id)
                {
                    StudentRepo.list.Remove(student);
                    break;
                }
            }
            return StudentRepo.list;
        }

        [HttpPost]
        public List<Student> InsertStudent([FromBody] Student student)
        {
            foreach (Student studentIter in StudentRepo.list)
            {
                if (studentIter.Id == student.Id)
                {
                    return StudentRepo.list; // student with id Id already exists
                }
            }
            StudentRepo.list.Add(student);
            return StudentRepo.list;
        }

        [HttpPut]
        public Student UpdateStudent([FromBody] Student student)
        {
            foreach (Student studentIter in StudentRepo.list)
            {
                if (studentIter.Id == student.Id)
                {
                    studentIter.Nume = student.Nume;
                    studentIter.Facultate = student.Facultate;
                    studentIter.An = student.An;
                    return studentIter;
                }
            }
            return null;
        }
    }
}
