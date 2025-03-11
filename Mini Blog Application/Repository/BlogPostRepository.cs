using Microsoft.EntityFrameworkCore;
using Mini_Blog_Application.DTO.Blog;
using Mini_Blog_Application.Interfaces;
using Mini_Blog_Application.Migrations;
using Mini_Blog_Application.Models;
using MiniBlogApplication.Models;

namespace Mini_Blog_Application.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {

        private readonly ApplicationDbContext _context;
        
        public BlogPostRepository(ApplicationDbContext context)
        {
            
            _context = context;
        }
        public async Task<List<BlogPost>> GetAllAsync()
        {
            return await _context.BlogPost.Include(c => c.Comments).ToListAsync();
        }
        public async Task<BlogPost> CreateAsync(BlogPost post)
        {

            try
            {
                await _context.BlogPost.AddAsync(post);
                await _context.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return post;
        }
        public async Task<BlogPost> DeleteAsync(string id)
        {
            var postModel = await _context.BlogPost.FirstOrDefaultAsync(x => x.Id.Equals(id));
            
            
            if (postModel == null)
            {
                return null;
            }

            try
            {
                _context.BlogPost.Remove(postModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            await _context.SaveChangesAsync();
            return postModel;

        }

        public async Task<BlogPost?> GetByIdAsync(string id)
        {
            return await _context.BlogPost.Include(c => c.Comments).FirstOrDefaultAsync(b => b.Id.Equals(id));
        }

        public async Task<BlogPost> UpdateAsync(string id, UpdateBlogPostRequestDto blogDto)
        {
            var existingPost = await _context.BlogPost.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (existingPost == null)
            {
                return null;
            }

            try
            {

                existingPost.Title = blogDto.Title;
                existingPost.Content = blogDto.Content;
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

            await _context.SaveChangesAsync();

            return existingPost;



        }


    }
}
