using Mini_Blog_Application.DTO;
using Mini_Blog_Application.DTO.Comment;
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

        public static Comment ToCommentFromCreate(this CreateCommentDTO commentModel, string blogId)
        {
            return new Comment
            {
         
                Content = commentModel.Content,

                BlogPostId = blogId
            };
        }
    }
}
