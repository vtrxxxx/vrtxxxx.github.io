using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Contract.Responses
{
    public class SessionResponse
    {
        public int Id {  get; set; }
        public int MovieID { get; set; }    
        public string RoomName { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; } 
        public TimeSpan EndTime { get; set; } 
        public MovieResponse MovieResponse { get; set; }
    }
}
