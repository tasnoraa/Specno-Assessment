using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using SpecnoRepository.Models;

namespace Specno_Assessment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RedditController : ControllerBase
    {
        IRedditService _redditService;
        public RedditController(IRedditService redditService)
        {
            _redditService = redditService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_redditService.GetPosts());
        }

        
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            return Ok(_redditService.GetUsers());
        }

        [HttpPost("addPost")]
        public IActionResult Post(Post post)
        {
            _redditService.Post(post);
            return CreatedAtAction("Get", new { id = post.PostId}, post);
        }

        [HttpPost("updatePost")]
        public IActionResult UpdatePost(Post post)
        {
            if (_redditService.UpdatePost(post))
                return NoContent();
            else
                return NotFound();
        }

        [HttpPost("deletePost")]
        public IActionResult DeletePost(Post post)
        {
            if (_redditService.DeletePost(post))
                return NoContent();
            else
                return NotFound();
        }

        [HttpPost("addComment")]
        public IActionResult Comment(Comment comment)
        {
            _redditService.Comment(comment);
            return CreatedAtAction("Get", new { id = comment.PostId }, comment);
        }

        [HttpPost("addVote")]
        public IActionResult Vote(Like like)
        {
            _redditService.Like(like);
            return CreatedAtAction("Get", new { id = like.PostId }, like);
        }
    }
}
