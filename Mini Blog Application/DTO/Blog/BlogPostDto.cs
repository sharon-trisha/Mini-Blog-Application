using MiniBlogApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mini_Blog_Application.DTO.Blog
{
    public class BlogPostDto
    {

        
        public string Id { get; set; }
        
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public User Author { get; set; }
    }
}
