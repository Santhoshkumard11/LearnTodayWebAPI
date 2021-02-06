using LearnTodayWebAPI.DAL;
using LearnTodayWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LearnTodayWebAPI.Controllers
{
    public class TrainerController : ApiController
    {
        private LearnTodayWebAPIContext db = new LearnTodayWebAPIContext();

        // POST: api/Trainer
        [HttpPost]
        public HttpResponseMessage TrainerSignUp([FromBody]Trainer  trainer)
        {
            try
            {

                db.Tainers.Add(trainer);
                db.SaveChanges();


            }
            catch (Exception ex)
            {

                return GenerateResponseMessage(400, ex);
            }

            return GenerateResponseMessage(202, trainer);

        }

        // PUT: api/Trainer/5
        [HttpPut]
        public HttpResponseMessage UpdatePassword(int id, [FromBody]Trainer trainer)
        {
            if (!ModelState.IsValid)
            {
                return GenerateResponseMessage(200, "Make sure you have all the model values correct!!");
            }

            db.Entry(trainer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainerExists(id))
                {
                    return GenerateResponseMessage(200, $"Searched Data not found");
                }

            }

            return GenerateResponseMessage(200, "Data Updated successfully!");

        }

        private bool TrainerExists(int id)
        {
            return db.Tainers.Count(t => t.TrainerId == id) > 0;
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
