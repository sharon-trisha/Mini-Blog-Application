using Microsoft.AspNetCore.Identity;
using System.Runtime.InteropServices;

namespace MiniBlogApplication.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
