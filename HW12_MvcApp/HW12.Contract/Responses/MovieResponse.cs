using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Contract.Responses
{
    public class MovieResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }   
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public List<SessionResponse> Sessions { get; set; } = new List<SessionResponse>();

    }
}
