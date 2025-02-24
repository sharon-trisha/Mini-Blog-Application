using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll()
        {
            var blogs = _context.BlogPost.ToList()
                .Select(b => b.ToBlogPostDto());

            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] string id)
        {
            var blog = _context.BlogPost.Find(id);

            if (blog == null)
            {
                return BadRequest();
            }

            return Ok(blog.ToBlogPostDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateBlogPostRequestDto BlogDto)
        {
            var blogModel = BlogDto.ToBlogPostFromCreateDto();
            _context.BlogPost.Add(blogModel);

            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = blogModel.Id }, blogModel.ToBlogPostDto());
        }
    }
}
