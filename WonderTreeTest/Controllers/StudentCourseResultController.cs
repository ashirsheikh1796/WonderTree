using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using WonderTreeTest.Models;

namespace WonderTreeTest.Controllers
{
    public class StudentCourseResultController : ApiController
    {
        private WonderTreeContext db = new WonderTreeContext();

        [HttpPost]
        public IHttpActionResult Add([FromBody] Student_Course_Result obj)
        {
            try
            {
                db.Student_Course_Results.Add(obj);
                db.SaveChanges();
                return Ok("record has been saved succesfully.");
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

        [HttpPost]
        public IHttpActionResult Update([FromBody] Student_Course_Result obj)
        {
            try
            {
                var result = db.Student_Course_Results.Find(obj.ResultId);
                result.StudentId = obj.StudentId;
                result.CourseId = obj.CourseId;
                result.Date_Time = obj.Date_Time;
                result.Score = obj.Score;
                db.Entry(result).State = EntityState.Modified;
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