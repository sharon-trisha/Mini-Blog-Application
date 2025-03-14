using Microsoft.EntityFrameworkCore;
using Mini_Blog_Application.DTO.Blog;
using Mini_Blog_Application.Helper;
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
        public async Task<List<BlogPost>> GetAllAsync(QueryObject query)
        {
            var blogs = _context.BlogPost.Include(c => c.Comments).AsQueryable();

            if(!string.IsNullOrWhiteSpace(query.Title))
            {
                blogs = blogs.Where(b => b.Title.Contains(query.Title));
            }

            if(!string.IsNullOrWhiteSpace(query.Author))
            {
                blogs = blogs.Where(b => b.UserId.Contains(query.Author));
            }

            if(!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if(query.SortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    blogs = query.IsDescending ? blogs.OrderByDescending(s => s.Title) : blogs.OrderBy(b => b.Title);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;


            return await blogs.Skip(skipNumber).Take(query.PageSize).ToListAsync();
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

        public Task<bool> BlogExist(string id)
        {
            return _context.BlogPost.AnyAsync(b => b.Id.Equals(id));
        }
    }
}
