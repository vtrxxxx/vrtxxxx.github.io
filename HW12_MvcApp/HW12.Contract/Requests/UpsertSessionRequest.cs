using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Contract.Requests
{
    public class UpsertSessionRequest
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "Название комнаты обязательно.")]
        [StringLength(10, ErrorMessage = "Название комнаты не должно превышать 10 символов.")]
        public string RoomName { get; set; }

        [Required(ErrorMessage = "Дата обязательна.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Время начала обязательно.")]
        [EndTimeGreaterThanStartTime(ErrorMessage = "Время окончания должно быть позже времени начала.")]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "Время окончания обязательно.")]
        [EndTimeGreaterThanStartTime(ErrorMessage = "Время окончания должно быть позже времени начала.")]
        public TimeSpan EndTime { get; set; }

        [Required(ErrorMessage = "Id фильма обязательно.")]
        public int MovieId { get; set; }

    }
}
