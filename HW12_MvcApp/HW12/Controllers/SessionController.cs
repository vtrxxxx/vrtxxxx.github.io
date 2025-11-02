using Microsoft.AspNetCore.Mvc;
using HW12.Service.Queries;
using HW12.Contract.Responses;
using HW12.Service;
using HW12.Data.Models;
using HW12.Contract.Requests;
using HW12.Service.Commands;
using AspNetCoreHero.ToastNotification.Abstractions;
using MovieManager.Service.Commands;

namespace HW12.Controllers
{
    public class SessionController : Controller
    {
        private readonly INotyfService _notifyService;

        public SessionController(INotyfService notifyService)
        {
            _notifyService = notifyService;
        }

        [HttpGet]
        public async Task<IActionResult> UpsertSession(int movieId)
        {
            return View(new UpsertSessionRequest
            {
                MovieId = movieId
            });
        }


        [HttpPost]
        public async Task<IActionResult> UpsertSession([FromServices] IRequestHandler<UpsertSessionCommand, SessionResponse> upsertSession, UpsertSessionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);  
            }

            bool isCreating = request.Id == null || request.Id == 0;

            var sessionResponse = await upsertSession.Handle(new UpsertSessionCommand
            {
                SessionId = request.Id,
                MovieId = request.MovieId,
                RoomName = request.RoomName,
                StartDate = request.StartDate,
                StartTime = request.StartTime,
                EndTime = request.EndTime
            });

            if (isCreating)
            {
                _notifyService.Success("Cеанс успешно создан!");
            }
            return RedirectToAction("Index","Movie");
        }

        



    }
}

