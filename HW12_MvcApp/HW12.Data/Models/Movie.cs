using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Data.Models
{
    [Table("Movies")]
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; } 
        [Required]
        [StringLength(50)]
        public string Director { get; set; }

        [Required]
        [StringLength(100)]
        public string Genre { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
        public ICollection<Session> Sessions { get; set; } = new List<Session>();   
    }
}
