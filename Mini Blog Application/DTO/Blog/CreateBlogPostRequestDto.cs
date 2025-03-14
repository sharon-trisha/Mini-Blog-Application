using MiniBlogApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mini_Blog_Application.DTO.Blog
{
    public class CreateBlogPostRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title cannot be less than 5 characters")]
        [MaxLength(50, ErrorMessage = "Title cannot be more than 50 characters")]
        public string Title { get; set; }

        [Required]
        [MinLength(0, ErrorMessage = "Title cannot be less than 0 characters")]
        [MaxLength(50, ErrorMessage = "Title cannot be more than 50 characters")]
        public string Content { get; set; }
        
    }
}
