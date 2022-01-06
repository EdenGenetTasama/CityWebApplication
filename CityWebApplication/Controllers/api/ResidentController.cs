﻿using CityWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CityWebApplication.Controllers.api
{
    public class ResidentController : ApiController
    {
        static string stringConnection = "Data Source=DESKTOP-0MT6QTG;Initial Catalog=CityDb;Integrated Security=True;Pooling=False";
        CityDataContextDataContext dataContext = new CityDataContextDataContext(stringConnection);

        // GET: api/Resident
        public IHttpActionResult Get()
        {
            try
            {
                List<Resident> listOFResident = dataContext.Residents.ToList();
                return Ok(new { listOFResident });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Resident/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Resident listOfResident = dataContext.Residents.First(ResidentItem => ResidentItem.Id == id);
                return Ok(listOfResident);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        //add new obj to list
        // POST: api/Resident
        public IHttpActionResult Post([FromBody] Resident redisterObj)
        {

            dataContext.Residents.InsertOnSubmit(redisterObj);
            dataContext.SubmitChanges();
            return Ok($"Added {redisterObj.first_name}");
        }

        //update old obj in list
        // PUT: api/Resident/5
        public IHttpActionResult Put(int id, [FromBody] Resident redisterObj)
        {
            return Ok();
        }

        // DELETE: api/Resident/5
        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }
    }
}