using Mini_Blog_Application.DTO.Blog;
using MiniBlogApplication.Models;
using System.Runtime.CompilerServices;

namespace Mini_Blog_Application.Mappers
{
    public static class BlogPostMappers
    {
        public static BlogPostDto ToBlogPostDto(this BlogPost blogModel)
        {
            return new BlogPostDto
            {
                Id = blogModel.Id,
                Title = blogModel.Title,
                Content = blogModel.Content,
                CreatedAt = blogModel.CreatedAt,
                Author = blogModel.Author,
                Comments = blogModel.Comments.Select(c => c.ToCommentDto()).ToList()
            };
        }

        public static BlogPost ToBlogPostFromCreateDto(this CreateBlogPostRequestDto blogDto)
        {
            return new BlogPost
            {
                Title = blogDto.Title,
                Content = blogDto.Content,

            };
        }
    }
}
