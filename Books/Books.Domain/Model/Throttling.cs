using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Domain.Model
{
    public class Throttling
    {
        public int Id { get; set; }

        public string Endpoint { get; set; }

        public int Seconds { get; set; }

        public int Minute { get; set; }

        public int Hours { get; set; }
    }
}
