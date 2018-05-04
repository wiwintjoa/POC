using DataAccess;
using Newtonsoft.Json;
using Resources.API.Filter;
using System.Web.Http;

namespace Resources.API
{
    //[Authorize]
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }
        
        [Route("GetAll")]
        [Throttle(Name = "TestThrottle", Message = "You must wait {n} seconds before accessing this url again.", Seconds = 5)]
        public IHttpActionResult GetUsers()
        {
            var users = _repository.GetAll();

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return Ok(json);
        }

        [Route("GetByEmail")]
        public IHttpActionResult GetUserByEmail(string email)
        {
            var user = _repository.GetByEmail(email);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}