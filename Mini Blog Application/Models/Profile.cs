using MiniBlogApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Blog_Application.Models
{
    [Table("Profiles")]
    public class Profile
    {
        
        public string UserId { get; set; }
        public string BlogId { get; set; }
        public User User { get; set; }
        public BlogPost BlogPost { get; set; }
    }
}
