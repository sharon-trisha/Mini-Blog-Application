
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniBlogApplication.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign keys
        public string BlogPostId { get; set; }
        [ForeignKey("BlogPostId")]
        public BlogPost BlogPost { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User Author { get; set; }


    }
}
