using Asp.Versioning;
using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Models.ViewModels;
using FA.JustBlog.Core.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.API.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TagController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("add-tag")]
        public IActionResult CreateTag([FromBody] TagVM tagVM)
        {
            var tag = _mapper.Map<Tag>(tagVM);
            _unitOfWork.TagRepository.Add(tag);
            var result = _unitOfWork.Save();
            if (result > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("get-all-tags")]
        public IActionResult GetAllTags()
        {
            var tags = _unitOfWork.TagRepository.GetAll();
            if (tags == null)
            {
                return NotFound();
            }
            var tagsVM = _mapper.Map<List<TagVM>>(tags);
            return Ok(tagsVM);
        }

        [HttpGet("get-tag-by-id/{id}")]
        public IActionResult GetTag(int id)
        {
            var tag = _unitOfWork.TagRepository.Find(id);
            if (tag != null)
            {
                var tagVM = _mapper.Map<TagVM>(tag);
                return Ok(tagVM);
            }
            return NotFound();
        }

        [HttpGet("get-tags-by-page")]
        public IActionResult GetTagsByPage(int? page, int? pageSize)
        {
            var tags = _unitOfWork.TagRepository.GetAll();
            if (tags == null)
            {
                return NotFound();
            }

            if (page.HasValue && pageSize.HasValue)
            {
                tags = tags.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList();
            }

            var tagsVM = _mapper.Map<List<TagVM>>(tags);
            return Ok(tagsVM);
        }

        [HttpPut("update-tag-by-id/{id}")]
        public IActionResult UpdateTag(int id, [FromBody] TagVM tagVM)
        {
            var tag = _unitOfWork.TagRepository.Find(id);
            if (tag != null)
            {
                tag.Name = tagVM.Name;
                tag.UrlSlug = tagVM.UrlSlug;
                tag.Description = tagVM.Description;
                var result = _unitOfWork.Save();
                if (result > 0)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpDelete("delete-tag-by-id/{id}")]
        public IActionResult DeleteTag(int id)
        {
            var tag = _unitOfWork.TagRepository.Find(id);
            if (tag != null)
            {
                _unitOfWork.TagRepository.Delete(tag);
                var result = _unitOfWork.Save();
                if (result > 0)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
