using DataAccess;
using Newtonsoft.Json;
using System.Web.Http;
using WebApiThrottle;

namespace Resources.API
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        private IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }


        //[Authorize]
        [Route("GetAll")]
        [EnableThrottling(PerSecond = 3)]
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