using LearnTodayWebAPI.DAL;
using LearnTodayWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnTodayWebAPI.Controllers
{
    public class StudentController : ApiController
    {

        private LearnTodayWebAPIContext db = new LearnTodayWebAPIContext();

        // GET: api/Student
        public IEnumerable<Course> GetAllCourses()
        {
            return db.Courses.OrderBy(c => c.StartDate);
        }

        // POST: api/Student
        public HttpResponseMessage PostStudents([FromBody]Student student)
        {

            try
            {

                db.Students.Add(student);
                db.SaveChanges();

            }
            catch (Exception ex)
            {

                return GenerateResponseMessage(400,ex);
            }

            return GenerateResponseMessage(202, student);

        }


        // DELETE: api/Student/5
        public HttpResponseMessage DeleteStudent(int id)
        {
            try
            {
                Student queriedStudent = db.Students.FirstOrDefault(s => s.EndrolemnentId == id);


                if (queriedStudent == null)
                {
                    return GenerateResponseMessage(400, $"No enrollment information found");
                }
                else
                {
                    db.Students.Remove(queriedStudent);
                    db.SaveChanges();

                    return GenerateResponseMessage(202, $"Student with Id {id} deleted successfully!!");
                }

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }


        }

        //create a method which will return a response by taking in the status code and message
        /// <summary>
        /// Generate the response for the 
        /// </summary>
        /// <param name="statusCode">Response Status Code</param>
        /// <param name="message"> Message as string or models</param>
        /// <returns>Http response message</returns>
        public HttpResponseMessage GenerateResponseMessage(int statusCode, object message)
        {

            var statusCodeType = new object();

            switch (statusCode)
            {
                case 200: { statusCodeType = HttpStatusCode.OK; break; }
                case 202: { statusCodeType = HttpStatusCode.Accepted; break; }
                case 400: { statusCodeType = HttpStatusCode.BadRequest; break; }

                default:
                    break;
            }

            return Request.CreateResponse((HttpStatusCode)statusCodeType, message);

        }
    }
}
