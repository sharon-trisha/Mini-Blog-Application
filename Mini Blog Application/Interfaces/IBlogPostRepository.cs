using Mini_Blog_Application.DTO.Blog;
using Mini_Blog_Application.Helper;
using MiniBlogApplication.Models;

namespace Mini_Blog_Application.Interfaces
{
    public interface IBlogPostRepository
    {
        Task<List<BlogPost>> GetAllAsync(QueryObject query);
        Task<BlogPost?> GetByIdAsync(string id);
        Task<BlogPost> CreateAsync(BlogPost post);
        Task<BlogPost> UpdateAsync(string id, UpdateBlogPostRequestDto
            blogDto);
        Task<BlogPost> DeleteAsync(string id);

        Task<bool> BlogExist(string id);
    }
}
