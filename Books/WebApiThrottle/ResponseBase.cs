using System.Collections.Generic;

namespace WebApiThrottle
{
    public class ResponseBase<TObjectResult>
    {
        public bool success { get; set; }

        public int total { get; set; }

        public int _id { get; set; }

        public TObjectResult lst { get; set; }

        private List<MessageBase> _messages = new List<MessageBase>();

        public List<MessageBase> messages
        {
            get
            {
                return _messages;
            }
            set
            {
                _messages = value;
            }
        }
    }
}