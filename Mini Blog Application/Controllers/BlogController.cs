using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mini_Blog_Application.DTO.Blog;
using Mini_Blog_Application.Interfaces;
using Mini_Blog_Application.Mappers;
using Mini_Blog_Application.Models;

namespace Mini_Blog_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        private ApplicationDbContext _context;
        private readonly IBlogPostRepository _blogRepo;
        public BlogController(ApplicationDbContext context, IBlogPostRepository blogRepo)
        {
            _blogRepo = blogRepo;
            _context = context;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var blogs = await _blogRepo.GetAllAsync();
            var blogModel = blogs.Select(b => b.ToBlogPostDto());

            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var blog = await _blogRepo.GetByIdAsync(id);

            if (blog == null)
            {
                return BadRequest();
            }

            return Ok(blog.ToBlogPostDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBlogPostRequestDto BlogDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blogModel = BlogDto.ToBlogPostFromCreateDto();


            await _blogRepo.CreateAsync(blogModel);

            
            return CreatedAtAction(nameof(GetById), new { id = blogModel.Id }, blogModel.ToBlogPostDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateBlogPostRequestDto UpdateDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blog = await _blogRepo.UpdateAsync(id, UpdateDto);

            if(blog == null)
            {
                return NotFound();
            }

            

            

            return Ok(blog.ToBlogPostDto());
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var blogModel = await _blogRepo.DeleteAsync(id);
            
            if(blogModel == null)
            {
                return BadRequest();
            }

            

            

            return NoContent();
        }
    }
}
