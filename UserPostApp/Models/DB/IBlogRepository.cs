namespace UserPostApp.Models.DB
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
    }
}
