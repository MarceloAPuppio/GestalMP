using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;

namespace WebDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolController : Controller
    {
        // GET: api/Rol
        [HttpGet]
        public JsonResult Get()
        {
            return Json(new { data="oaaaaaaaaaaaa"});
        }

        //// GET: api/Rol/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Rol
        [HttpPost]
        public JsonResult Post([FromForm] MODELS.Rol rol)
        {
            var BLLR = new BLLRoles();
            return Json(new { data = "petacular" });
        }

        // PUT: api/Rol/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
