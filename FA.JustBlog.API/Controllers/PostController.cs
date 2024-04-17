using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Models.ViewModels;
using FA.JustBlog.Core.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("add-post")]
        public IActionResult CreatePost([FromBody] PostVM postVM)
        {
            var post = _mapper.Map<Post>(postVM);
            _unitOfWork.PostRepository.Add(post);
            var result = _unitOfWork.Save();
            if (result > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("get-all-posts")]
        public IActionResult GetAllPosts()
        {
            var posts = _unitOfWork.PostRepository.GetAll();
            if (posts == null)
            {
                return NotFound();
            }
            var postsVM = _mapper.Map<List<PostVM>>(posts);
            return Ok(postsVM);
        }

        [HttpGet("get-post-by-id/{id}")]
        public IActionResult GetPost(int id)
        {
            var post = _unitOfWork.PostRepository.Find(id);
            if (post != null)
            {
                var postVM = _mapper.Map<PostVM>(post);
                return Ok(postVM);
            }
            return NotFound();
        }

        [HttpPut("update-post-by-id/{id}")]
        public IActionResult UpdatePost(int id, [FromBody] PostVM postVM)
        {
            var post = _unitOfWork.PostRepository.Find(id);
            if (post != null)
            {
                _mapper.Map(postVM, post);
                var result = _unitOfWork.Save();
                if (result > 0)
                {
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpDelete("delete-post-by-id/{id}")]
        public IActionResult DeletePost(int id)
        {
            var post = _unitOfWork.PostRepository.Find(id);
            if (post != null)
            {
                _unitOfWork.PostRepository.Delete(post);
                var result = _unitOfWork.Save();
                if (result > 0)
                {
                    return Ok();
                }
            }
            return NotFound();
        }
    }
}
