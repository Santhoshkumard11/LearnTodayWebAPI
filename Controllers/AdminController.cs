using LearnTodayWebAPI.DAL;
using LearnTodayWebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace LearnTodayWebAPI.Controllers
{
    public class AdminController : ApiController
    {
        private LearnTodayWebAPIContext db = new LearnTodayWebAPIContext();

        // GET: api/Courses
        public IEnumerable<Course> GetAllCourses()
        {
            return db.Courses;
        }

        // GET: api/Courses/5
        [ResponseType(typeof(Course))]
        public HttpResponseMessage GetCourseById(int id)
        {
            Course course = db.Courses.Find(id);

            if (course == null)
            {
                return GenerateResponseMessage(400, $"Course with Id {id} not found!!");
            }

            return GenerateResponseMessage(200, course);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourseExists(int id)
        {
            return db.Courses.Count(e => e.Id == id) > 0;
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