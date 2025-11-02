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
    public class GetMoviesQueryHandler : IRequestHandler<IList<MovieResponse>>
    {
        private readonly ApplicationDbContext _context;

        public GetMoviesQueryHandler (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<MovieResponse>> Handle()
        {
            return await _context.Movies
               .AsNoTracking()
               .Include(movie => movie.Sessions)
               .Select(movie => new MovieResponse
               {
                   Id = movie.Id,
                   Title = movie.Title,
                   Director = movie.Director,
                   Genre = movie.Genre,
                   Description = movie.Description,
                   Sessions = movie.Sessions.Select(session => new SessionResponse
                   {
                       Id = session.Id,
                       RoomName = session.RoomName,
                       StartDate = session.StartDate,
                       StartTime = session.StartTime,
                       EndTime = session.EndTime
                   }).ToList()
               })
               .OrderByDescending(x => x.Id)
               .ToListAsync();
        }
        
                
        
    }
}
   