namespace UserPostApp.Models.DB
{
    public interface ILogRepository
    {
        Task AddLog(Request request);
        Task<Request[]> GetLog();
    }
}
