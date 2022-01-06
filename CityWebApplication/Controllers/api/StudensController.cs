using CityWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CityWebApplication.Controllers.api
{
    public class StudensController : ApiController
    {
        static string stringConection = "Data Source=DESKTOP-0MT6QTG;Initial Catalog=CityDb;Integrated Security=True;Pooling=False";
        StudentsDataContext dataConext = new StudentsDataContext(stringConection);
        // GET: api/Studens
        public IHttpActionResult Get()
        {
            List<School> Student = dataConext.Schools.ToList();
            return Ok(Student);
        }

        // GET: api/Studens/5
        public IHttpActionResult Get(int id)
        {
            School Student = dataConext.Schools.First(item => item.Id == id);
            return Ok(Student);
        }

        // POST: api/Studens
        public IHttpActionResult Post([FromBody] School student)
        {
            dataConext.Schools.InsertOnSubmit(student);
            dataConext.SubmitChanges();
            return Ok("Added ☺");
        }

        // PUT: api/Studens/5
        public IHttpActionResult Put(int id, [FromBody] School student)
        {
            School personToUpdate = dataConext.Schools.First(item => item.Id == id);
            if (personToUpdate != null)
            {

                student.first_name = personToUpdate.first_name;
                student.street = personToUpdate.street;
                student.ifMamlacti = personToUpdate.ifMamlacti;
                student.numberOfStudies = personToUpdate.numberOfStudies;
                dataConext.SubmitChanges();
                return Ok($"Update {personToUpdate.first_name}");
            }
            return Ok($"Fail!");
        }

        // DELETE: api/Studens/5
        public IHttpActionResult Delete(int id)
        {
            School student = dataConext.Schools.First(item => item.Id == id);
            dataConext.Schools.DeleteOnSubmit(student);
            dataConext.SubmitChanges();
            return Ok();
        }
    }
}
