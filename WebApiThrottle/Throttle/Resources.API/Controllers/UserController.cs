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
        [EnableThrottling(PerSecond = 1)]
        public IHttpActionResult GetUsers()
        {
            var users = _repository.GetAll();

            string json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return Ok(json);
        }

        [Route("GetByEmail/{email}")]
        [DisableThrotting]
        public IHttpActionResult GetUserByEmail(string email)
        {
            var user = _repository.GetByEmail(email);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        ///// <summary>
        ///// Policy runtime update example
        ///// </summary>
        //[NonAction]
        //public void UpdateRateLimits()
        //{
        //    //init policy repo
        //    var policyRepository = new PolicyCacheRepository();

        //    //get policy object from cache
        //    var policy = policyRepository.FirstOrDefault(ThrottleManager.GetPolicyKey());

        //    //update client rate limits
        //    policy.ClientRules["api-client-key-1"] =
        //        new RateLimits { PerMinute = 50, PerHour = 500 };

        //    //add new client rate limits
        //    policy.ClientRules.Add("api-client-key-3",
        //        new RateLimits { PerMinute = 60, PerHour = 600 });

        //    //apply policy updates
        //    ThrottleManager.UpdatePolicy(policy, policyRepository);

        //}
    }
}