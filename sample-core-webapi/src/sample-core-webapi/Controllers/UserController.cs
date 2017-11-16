using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace sample_core_webapi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        [Route("LoginUser")]
        public AuthToken LoginUser(string username = "test", string password = "test")
        {
            AuthToken jWTToken = new AuthToken();

            var jwtToken = JwtManager.GetJwtSecurityToken(username);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(jwtToken);

            jWTToken.token = token;

            return jWTToken;
        }

        [Route("GetUsers")]
        public string GetUsers()
        {
            Microsoft.AspNetCore.Http.IHeaderDictionary headers = Request.Headers;

            return "Users found";
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
