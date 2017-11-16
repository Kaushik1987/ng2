using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using PagedList.Core;
using sample_core_webapi.Filters;
using sample_core_webapi.Model;

namespace sample_core_webapi.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("CorsPolicy")]
    public class ValuesController : Controller
    {
        SchoolContext _context;
        public ValuesController(SchoolContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Student> students;
                Pagination paginationMetadata;

                string paginationData = Request.Headers["X-Pagination"];
                if(paginationData != null)
                {
                    paginationMetadata = Newtonsoft.Json.JsonConvert.DeserializeObject<Pagination>(paginationData);
                }
                else
                {
                    paginationMetadata = new Pagination();
                    paginationMetadata.pageIndex = 0;
                    paginationMetadata.pageSize = 5;
                }

                using (var ctx = _context)
                {                  
                   students = ctx.Students.ToList();
                }

                foreach(Student std in students)
                {
                    std.edit = std.StudentID.ToString() ;
                }

                var studentPage = students.Skip(((paginationMetadata.pageIndex+1) - 1) * paginationMetadata.pageSize).Take(paginationMetadata.pageSize);

                //StaticPagedList<Student> staticStudent = new StaticPagedList<Student>(students, paginationMetadata.pageIndex, paginationMetadata.pageSize, paginationMetadata.totalCount);

                paginationMetadata = new Pagination
                {
                    totalCount = students.Count,
                    pageSize = paginationMetadata.pageSize,
                    pageIndex = paginationMetadata.pageIndex,
                    totalPages = (int)Math.Ceiling((decimal)students.Count/ paginationMetadata.pageSize)
                };

                Response.Headers.Add("X-Pagination",
                    Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

                return Ok(studentPage);

            }
            catch (Exception ex)
            {
                string exception = ex.Message;
            }
            return null;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public StudentModel Get(int id)
        {
            StudentModel stdModel;
            using (var ctx = _context)
            {
                stdModel = ctx.Students.Where(x => x.StudentID == id).Single().ToViewModel();
            }
            return stdModel;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]StudentModel studentModel)
        {
            Student student;
            using (var ctx = _context)
            {
                student = studentModel.ToStudent();

                ctx.Students.Add(student);
                ctx.SaveChanges();
            }
            return Ok(student.ToViewModel());
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]StudentModel studentModel)
        {
            using (var ctx = _context)
            {
                Student studentToUpdate = ctx.Students.Where(x => x.StudentID == id).Single();

                studentToUpdate.StudentName = studentModel.Name;
                studentToUpdate.Height = Decimal.Parse(studentModel.Height);
                studentToUpdate.Weight = float.Parse(studentModel.Weight);

                ctx.Entry(studentToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var ctx = _context)
            {
                Student student = ctx.Students.Where(x=> x.StudentID == id).FirstOrDefault();

                ctx.Students.Remove(student);
                ctx.SaveChanges();
            }
        }
       

    }

    public class AuthToken
    {
        public string token { get; set; }

    }
        public class Pagination
    {
        public int totalCount { get; set; }
        public int pageSize { get; set; }
        public int pageIndex { get; set; }
        public int totalPages { get; set; }        
    }

}
