using CarBook.Application.Features.Mediator.Commands.CreateCommentCommands;
using CarBook.Application.RepositoryPattern;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentsRepository;
        private readonly IMediator _mediator;

        public CommentsController(IGenericRepository<Comment> commentsRepository, IMediator mediator)
        {
            _commentsRepository = commentsRepository;
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentsRepository.GetAll();
            return Ok(values);

        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        { 
          var value = _commentsRepository.GetById(id);
            if (value == null)
            {
                return NotFound("Yorum bulunamadı");
            }
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _commentsRepository.Create(comment);
            return Ok("yorum başarı ile eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var value = _commentsRepository.GetById(id);
            if (value == null)
            {
                return NotFound("Yorum bulunamadı");
            }
            _commentsRepository.Remove(value);
            return Ok("Yorum başarı ile silindi");
        }
        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            var value = _commentsRepository.GetById(comment.CommentID);
            if (value == null)
            {
                return NotFound("Yorum bulunamadı");
            }
            value.Name = comment.Name;
            value.CreatedDate = comment.CreatedDate;
            value.Description = comment.Description;
            ;
            // varsa diğer alanlar...
            _commentsRepository.Update(comment);
            return Ok("Yorum başarı ile güncellendi");
        }
        [HttpGet("CommentListByBlog/{id}")]
        public IActionResult CommentListByBlog(int id)
        {
            var value = _commentsRepository.GetCommentsByBlogId(id);
            return Ok(value);
        }
        [HttpGet("GetCountCommentByBlog")]
        public IActionResult GetCountCommentByBlog(int id)

        {

            var values = _commentsRepository.GetCountCommentByBlog(id);
            return Ok(values);

        }
        [HttpPost("CreateCommentWithMediator")]

        public async Task<IActionResult> CreateCommentWithMediator(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yorum Başarı ile Eklendi");


        }

    }
}
