using HW12.Data;
using HW12.Data.Models;
using HW12.Service;
using Microsoft.EntityFrameworkCore;

namespace MovieManager.Service.Commands
{
    public class DeleteMovieCommand
    {
        public int MovieId { get; set; }
    }

    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public DeleteMovieCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteMovieCommand request)
        {
            var movie = await GetMovieAsync(request.MovieId);

            if (movie != null)
            {
                _context.Remove(movie);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        private async Task<Movie> GetMovieAsync(int movieId, CancellationToken cancellationToken = default)
        {
            return await _context.Movies.SingleOrDefaultAsync(x => x.Id == movieId);
        }
    }
}   
