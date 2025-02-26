using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_Blog_Application.DTO.Blog;
using Mini_Blog_Application.Mappers;
using Mini_Blog_Application.Models;

namespace Mini_Blog_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        private ApplicationDbContext _context;
        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _context.BlogPost.ToListAsync();
            var blogModel = blogs.Select(b => b.ToBlogPostDto());

            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var blog = await _context.BlogPost.FindAsync(id);

            if (blog == null)
            {
                return BadRequest();
            }

            return Ok(blog.ToBlogPostDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBlogPostRequestDto BlogDto)
        {
            var blogModel = BlogDto.ToBlogPostFromCreateDto();


            await _context.BlogPost.AddAsync(blogModel);

            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = blogModel.Id }, blogModel.ToBlogPostDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateBlogPostRequestDto UpdateDto)
        {
            var blog = await _context.BlogPost.FirstOrDefaultAsync(b => b.Id.Equals(id));

            if(blog == null)
            {
                return NotFound();
            }

            blog.Title = UpdateDto.Title;
            blog.Content = UpdateDto.Content;

            await _context.SaveChangesAsync();

            return Ok(blog.ToBlogPostDto());
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var blogModel = await _context.BlogPost.FirstOrDefaultAsync(x => (x.Id).Equals(id));
            
            if(blogModel == null)
            {
                return BadRequest();
            }

            _context.BlogPost.Remove(blogModel);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
