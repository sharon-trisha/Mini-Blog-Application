using Mini_Blog_Application.DTO;
using MiniBlogApplication.Models;

namespace Mini_Blog_Application.Mappers
{
    public static class CommentMapper
    {
        public static CommentDTO ToCommentDto(this Comment commentModel)
        {
            return new CommentDTO
            {
                Id = commentModel.Id,
                Content = commentModel.Content,
                CreatedAt = commentModel.CreatedAt,
                BlogPostId = commentModel.BlogPostId,
                UserId = commentModel.UserId
            };
        }
    }
}
