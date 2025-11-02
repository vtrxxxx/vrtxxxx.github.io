using HW12.Contract.Responses;
using HW12.Data.Models;
using System;
using System.Collections.Generic;
using HW12.Contract.Responses;
using HW12.Data;
using HW12.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW12.Service.Commands
{
    public class UpsertMovieCommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }

        public Movie UpsertMovie()
        {
            var movie = new Movie
            {
                Id = Id,
                Title = Title,
                Director = Director,
                Genre = Genre,
                Description = Description
            };

            return movie;
        }
    }

    public class UpsertMovieCommandHandler : IRequestHandler<UpsertMovieCommand, MovieResponse>
    {
        private readonly ApplicationDbContext _context;

        public UpsertMovieCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MovieResponse> Handle(UpsertMovieCommand request)
        {
            var movie = await _context.Movies.SingleOrDefaultAsync(m => m.Id == request.Id);

            if (movie == null)
            {
                movie = request.UpsertMovie();
                await _context.Movies.AddAsync(movie);
            }
            else
            {
                movie.Title = request.Title;
                movie.Director = request.Director;
                movie.Genre = request.Genre;
                movie.Description = request.Description;
            }
            await _context.SaveChangesAsync();

            return new MovieResponse
            {
                Id = movie.Id,
                Title = movie.Title,
                Director = movie.Director,
                Genre = movie.Genre,
                Description = movie.Description
            };
        }

    }
}
