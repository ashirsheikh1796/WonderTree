using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WonderTreeTest.Models;

namespace WonderTreeTest.Controllers
{
    public class StudentController : ApiController
    {
        private WonderTreeContext db = new WonderTreeContext();

        [HttpPost]
        public IHttpActionResult Add([FromBody] Student obj)
        {
            try
            {
                db.Students.Add(obj);
                db.SaveChanges();
                return Ok("record has been saved succesfully.");
            }
            catch(DbEntityValidationException ex)
            {
                var msg = ex.EntityValidationErrors.FirstOrDefault().ValidationErrors.FirstOrDefault().ErrorMessage;
                return Ok(new { code = (int)HttpStatusCode.InternalServerError, msg });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Student obj)
        {
            try
            {
                var student = db.Students.Find(obj.StudentId);
                student.FullName = obj.FullName;
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return Ok("record has been updated succesfully.");
            }
            catch (DbEntityValidationException ex)
            {
                var msg = ex.EntityValidationErrors.FirstOrDefault().ValidationErrors.FirstOrDefault().ErrorMessage;
                return Ok(new { code = (int)HttpStatusCode.InternalServerError, msg });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}