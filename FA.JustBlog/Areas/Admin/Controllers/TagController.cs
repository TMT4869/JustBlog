using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Models.ViewModels;
using FA.JustBlog.Core.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/{controller}/{action}")]
    public class TagController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TagController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var tags = _unitOfWork.TagRepository.GetAll();
            var tagsVM = _mapper.Map<List<TagVM>>(tags);
            return View(tagsVM);
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                var tag = _unitOfWork.TagRepository.Find(id.Value);
                if (tag != null)
                {
                    var tagVM = _mapper.Map<TagVM>(tag);
                    return View(tagVM);
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
        public IActionResult Create(TagVM tagVM)
        {
            if (ModelState.IsValid)
            {
                var tag = _mapper.Map<Tag>(tagVM);
                _unitOfWork.TagRepository.Add(tag);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var tag = _unitOfWork.TagRepository.Find(id.Value);
                if (tag != null)
                {
                    var tagVM = _mapper.Map<TagVM>(tag);
                    return View(tagVM);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TagVM tagVM)
        {
            if (ModelState.IsValid)
            {
                var tag = _mapper.Map<Tag>(tagVM);
                _unitOfWork.TagRepository.Update(tag);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _unitOfWork.TagRepository.Delete(id);
            _unitOfWork.Save();
            return Json(new { status = true });
        }
    }
}
