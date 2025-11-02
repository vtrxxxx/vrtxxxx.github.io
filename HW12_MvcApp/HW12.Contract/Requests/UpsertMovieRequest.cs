using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Contract.Requests
{
    public class UpsertMovieRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Название фильма обязательно.")]
        [StringLength(50, ErrorMessage = "Название фильма не должно превышать 100 символов.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Режиссёр фильма обязателен.")]
        [StringLength(50, ErrorMessage = "Режиссёр фильма не должен превышать 100 символов.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Жанр фильма обязателен.")]
        [StringLength(100, ErrorMessage = "Жанр фильма не должен превышать 100 символов.")]
        public string Genre { get; set; }

        [StringLength(500, ErrorMessage = "Описание фильма не должно превышать 500 символов.")]
        public string Description { get; set; }
    }
}

