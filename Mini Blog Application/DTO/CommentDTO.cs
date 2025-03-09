using MiniBlogApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mini_Blog_Application.DTO
{
    public class CommentDTO
    {
    
        public int Id { get; set; }
 
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }

        public string UserId { get; set; }

    }
}
