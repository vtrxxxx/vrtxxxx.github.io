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

namespace HW12.Service.Queries
{
    public class GetMovieByIdQueryHandler : IRequestHandler<int, MovieResponse>
    {
        private readonly ApplicationDbContext _context;

        public GetMovieByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<MovieResponse> Handle(int movieId)
        {
            var movie = await _context.Movies
            .AsNoTracking()
            .Include(m => m.Sessions) 
            .Where(m => m.Id == movieId)
            .Select(m => new MovieResponse
            {
                Id = m.Id,
                Title = m.Title,
                Director = m.Director,
                Genre = m.Genre,
                Description = m.Description,
                Sessions = m.Sessions.Select(s => new SessionResponse
                {
                    Id = s.Id,
                    RoomName = s.RoomName,
                    StartDate = s.StartDate,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime
                }).ToList()
            })
            .SingleOrDefaultAsync();

            return movie;
        }
    }
}
