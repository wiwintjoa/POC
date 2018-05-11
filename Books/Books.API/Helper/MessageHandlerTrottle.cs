using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebApiThrottle;

namespace Books.API.Helper
{
    public class MessageHandlerTrottle : DelegatingHandler
    {
        private readonly ThrottlingHandler _throttlingHandler;

        public MessageHandlerTrottle()
        {
            this._throttlingHandler = new ThrottlingHandler()
            {
                Policy = ThrottlePolicy.FromStore(new PolicyConfigurationProvider()),
                Repository = new CacheRepository()
            };
        }

        protected override Task<HttpResponseMessage> SendAsync(
       HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //_throttlingHandler.Policy = ThrottlePolicy.FromStore(new PolicyConfigurationProvider());
            //_throttlingHandler.Repository = new CacheRepository();

            //if (!string.IsNullOrEmpty(_throttlingHandler.QuotaExceededMessage))
            //{
                // Create the response.
                //var response = new HttpResponseMessage(HttpStatusCode.OK)
                //{
                //    Content = new StringContent(ComposeMessage(_throttlingHandler.QuotaExceededMessage))
                //};

                //_throttlingHandler.Dispose();
                //// Note: TaskCompletionSource creates a task that does not contain a delegate.
                //var tsc = new TaskCompletionSource<HttpResponseMessage>();
                //tsc.SetResult(response);   // Also sets the task state to "RanToCompletion"
                //return tsc.Task;
            //}

            return base.SendAsync(request, cancellationToken);

        }        

        //private string ComposeMessage(string strmessage)
        //{
        //    var result = new ResponseBase<List<object>>();
        //    var messages = new List<MessageBase>();
        //    var message = new MessageBase();
        //    message.message = strmessage;
        //    message.errorcode = 201;
        //    messages.Add(message);

        //    result.lst = null;
        //    result._id = -1;
        //    result.total = 0;
        //    result.success = false;
        //    result.messages = messages;

        //    string json = JsonConvert.SerializeObject(result, Formatting.None);

        //    return json;
        //}
    }

    
}