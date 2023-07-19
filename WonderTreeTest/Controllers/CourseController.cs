using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WonderTreeTest.Models;

namespace WonderTreeTest.Controllers
{
    public class CourseController : ApiController
    {
        private WonderTreeContext db = new WonderTreeContext();

        [HttpPost]
        public IHttpActionResult Add([FromBody] Course obj)
        {
            try
            {
                db.Courses.Add(obj);
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
    }
}