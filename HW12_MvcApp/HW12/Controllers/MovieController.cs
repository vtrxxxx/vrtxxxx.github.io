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
    public class MovieController : Controller
    {
        private readonly INotyfService _notifyService;

        public MovieController(INotyfService notifyService)
        {
            _notifyService = notifyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromServices] IRequestHandler<IList<MovieResponse>> getMoviesQuery)
        {
            return View(await getMoviesQuery.Handle());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int movieId, [FromServices] IRequestHandler<int, MovieResponse> getMovieByIdQuery)
        {
            var movie = await getMovieByIdQuery.Handle(movieId);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpGet]
        public async Task<IActionResult> UpsertMovie(int? movieId, [FromServices] IRequestHandler<int, MovieResponse> getMovieByIdQuery)
        {
            if (movieId.HasValue)
            {
                var movie = await getMovieByIdQuery.Handle(movieId.Value);
                if (movie == null)
                {
                    return NotFound();
                }

                return View(new UpsertMovieRequest
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Director = movie.Director,
                    Genre = movie.Genre,
                    Description = movie.Description
                });

            }
            return View(new UpsertMovieRequest());
        }

        [HttpPost]
        public async Task<IActionResult> UpsertMovie([FromServices] IRequestHandler<UpsertMovieCommand, MovieResponse> upsertMovie, UpsertMovieRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            bool isCreating = request.Id == null || request.Id == 0;

            var movieResponse = await upsertMovie.Handle(new UpsertMovieCommand
            {
                Id = request.Id,
                Title = request.Title,
                Director = request.Director,
                Genre = request.Genre,
                Description = request.Description

            });

            if (isCreating)
            {
                _notifyService.Success("Фильм успешно создан!");
            }
            else
            {
                _notifyService.Success("Фильм успешно обновлён!");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteMovie(int movieId, [FromServices] IRequestHandler<int, MovieResponse> getMovieByIdQuery)
        {
            var movie = await getMovieByIdQuery.Handle(movieId);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMovie(int movieId, [FromServices] IRequestHandler<DeleteMovieCommand, bool> deleteMovie)
        {
            var result = await deleteMovie.Handle(new DeleteMovieCommand { MovieId = movieId });

            if (result)
            {
                _notifyService.Success("Фильм был успешно удален.");
            }
            else
            {
                _notifyService.Error("Ошибка при удалении фильма.");
            }

            return RedirectToAction("Index");
        }
    }
}