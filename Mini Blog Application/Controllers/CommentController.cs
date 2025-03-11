using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_Blog_Application.DTO.Comment;
using Mini_Blog_Application.Interfaces;
using Mini_Blog_Application.Mappers;

namespace Mini_Blog_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IBlogPostRepository _blogRepo;
        public CommentController(ICommentRepository commentRepo, IBlogPostRepository blogRepo)
        {
            _commentRepo = commentRepo;
            _blogRepo = blogRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepo.GetAllAsync();

            var commentDto = comments.Select(s => s.ToCommentDto());

            return Ok(commentDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            var commentDto = comment.ToCommentDto();

            return Ok(commentDto);
        }

        [HttpPost("{blogId}")]
        public async Task<IActionResult> Create([FromRoute] string blogId, CreateCommentDTO commentDto)
        {

            if(!await _blogRepo.BlogExist(blogId))
            {
                return BadRequest("Blog does not exist");
            }

            var commentModel = commentDto.ToCommentFromCreate(blogId);
            await _commentRepo.CreateAsync(commentModel);

            return CreatedAtAction(nameof(GetById), new { id = commentModel }, commentModel.ToCommentDto());

        }
    }
}
