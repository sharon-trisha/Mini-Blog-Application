using Mini_Blog_Application.DTO.Blog;
using MiniBlogApplication.Models;

namespace Mini_Blog_Application.Interfaces
{
    public interface IBlogPostRepository
    {
        Task<List<BlogPost>> GetAllAsync();
        Task<BlogPost?> GetByIdAsync(string id);
        Task<BlogPost> CreateAsync(BlogPost post);
        Task<BlogPost> UpdateAsync(string id, UpdateBlogPostRequestDto
            blogDto);
        Task<BlogPost> DeleteAsync(string id);
    }
}
