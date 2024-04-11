using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Models.ViewModels;
using FA.JustBlog.Core.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/{controller}/{action}")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll();
            var categoriesVM = _mapper.Map<List<CategoryVM>>(categories);
            return View(categoriesVM);
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                var category = _unitOfWork.CategoryRepository.Find(id.Value);
                if (category != null)
                {
                    var categoryVM = _mapper.Map<CategoryVM>(category);
                    return View(categoryVM);
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(categoryVM);
                _unitOfWork.CategoryRepository.Add(category);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var category = _unitOfWork.CategoryRepository.Find(id.Value);
                if (category != null)
                {
                    var categoryVM = _mapper.Map<CategoryVM>(category);
                    return View(categoryVM);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryVM categoryVM)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(categoryVM);
                _unitOfWork.CategoryRepository.Update(category);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _unitOfWork.CategoryRepository.Delete(id);
            _unitOfWork.Save();
            return Json(new { status = true });
        }
    }
}
