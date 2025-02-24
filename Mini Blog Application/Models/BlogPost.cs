
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniBlogApplication.Models
{
    public class BlogPost
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Key
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User Author { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
