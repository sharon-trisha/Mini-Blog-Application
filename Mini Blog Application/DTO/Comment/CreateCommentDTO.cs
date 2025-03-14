using MiniBlogApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace Mini_Blog_Application.DTO.Comment
{
    public class CreateCommentDTO
    {
        [Required]
        [MinLength(5, ErrorMessage = "Content cannot be less than 5 characters")]
        [MaxLength(280, ErrorMessage = "Content cannot be more than 280 characters")]

        public string Content { get; set; }
        

        

    }
}
