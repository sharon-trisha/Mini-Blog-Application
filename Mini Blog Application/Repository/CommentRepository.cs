using Microsoft.EntityFrameworkCore;
using Mini_Blog_Application.Interfaces;
using Mini_Blog_Application.Models;
using MiniBlogApplication.Models;

namespace Mini_Blog_Application.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }
    }
}
