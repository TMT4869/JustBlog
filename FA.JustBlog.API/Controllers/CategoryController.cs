using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Models.ViewModels;
using FA.JustBlog.Core.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Authorize(Roles = "BlogOwner, Contributor")]
        [HttpPost("add-category")]
        public IActionResult CreateCategory([FromBody] CategoryVM categoryVM)
        {
            var category = _mapper.Map<Category>(categoryVM);
            _unitOfWork.CategoryRepository.Add(category);
            var result = _unitOfWork.Save();
            if (result > 0)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("get-all-categories")]
        public IActionResult GetAllCategories()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll();
            if (categories == null)
            {
                return NotFound();
            }
            var categoriesVM = _mapper.Map<List<CategoryVM>>(categories);
            return Ok(categoriesVM);
        }

        [HttpGet("get-category-by-id/{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _unitOfWork.CategoryRepository.Find(id);
            if (category != null)
            {
                var categoryVM = _mapper.Map<CategoryVM>(category);
                return Ok(categoryVM);
            }
            return NotFound();
        }

        [Authorize(Roles = "BlogOwner, Contributor")]
        [HttpPut("update-category-by-id/{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryVM categoryVM)
        {
            var category = _unitOfWork.CategoryRepository.Find(id);
            if (category != null)
            {
                category.Name = categoryVM.Name;
                category.UrlSlug = categoryVM.UrlSlug;
                category.Description = categoryVM.Description;
                _unitOfWork.CategoryRepository.Update(category);
                var result = _unitOfWork.Save();
                if (result > 0)
                {
                    return Ok();
                }
            }
            return NotFound();
        }

        [Authorize(Roles = "BlogOwner")]
        [HttpDelete("delete-category-by-id/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _unitOfWork.CategoryRepository.Find(id);
            if (category != null)
            {
                _unitOfWork.CategoryRepository.Delete(category);
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
