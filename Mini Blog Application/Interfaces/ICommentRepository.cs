using MiniBlogApplication.Models;

namespace Mini_Blog_Application.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
    }
}
