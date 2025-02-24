using MiniBlogApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mini_Blog_Application.DTO.Blog
{
    public class CreateBlogPostRequestDto
    {

        public string Title { get; set; }
        public string Content { get; set; }
        
    }
}
