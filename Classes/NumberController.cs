using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using FactsAboutNumbers.Data;
using Microsoft.AspNetCore.Authorization;

namespace FactsAboutNumbers.Classes
{    
    [Route("api")]
    [ApiController]
    public class NumberController : ControllerBase
    {
        ApplicationDbContext controller;

        public NumberController(ApplicationDbContext context)
        {
            controller = context;
        }
        
        [HttpGet]        
        public JsonResult Get(int number)
        {
            try
            {
                string fact = controller.NumberFacts.Where(x => x.Number == number).Select(x => x.Fact).Single();
                return new JsonResult(new NumberFact { Number = number, Fact = fact });
            }
            catch
            {
                return new JsonResult(new NumberFact { Number = number, Fact = $"No fact was found for number {number}! Please add a new one!" });
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Post([FromBody] NumberFact value)
        {
            try
            {
                NumberFact dbValue = controller.NumberFacts.Where(x => x.Number == value.Number).SingleOrDefault();
                if (dbValue == null)
                {
                    controller.NumberFacts.Add(value);
                }
                else
                {
                    dbValue.Fact = value.Fact;
                }
                controller.SaveChanges();

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
