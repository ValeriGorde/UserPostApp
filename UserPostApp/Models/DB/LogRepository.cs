using Microsoft.EntityFrameworkCore;

namespace UserPostApp.Models.DB
{
    public class LogRepository : ILogRepository
    {
        private readonly BlogContext _context;
        public LogRepository(BlogContext context) 
        {
            _context = context;
        }
        public async Task AddLog(Request request)
        {
            request.Date = DateTime.Now;
            request.Id = Guid.NewGuid();

            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetLog()
        {
            return await _context.Requests.ToArrayAsync();
        }
    }
}
