using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Models.ViewModels;
using FA.JustBlog.Core.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/{controller}/{action}")]
    public class CommentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var comments = _unitOfWork.CommentRepository.GetAll().ToList();
            var commentsVM = _mapper.Map<List<CommentVM>>(comments);
            return View(commentsVM);
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                var comment = _unitOfWork.CommentRepository.Find(id.Value);
                if (comment != null)
                {
                    var commentVM = _mapper.Map<CommentVM>(comment);
                    return View(commentVM);
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            ViewBag.PostId = new SelectList(_unitOfWork.PostRepository.GetAll(), "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CommentVM commentVM)
        {
            if (ModelState.IsValid)
            {
                var comment = _mapper.Map<Comment>(commentVM);
                _unitOfWork.CommentRepository.Add(comment);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.PostId = new SelectList(_unitOfWork.PostRepository.GetAll(), "Id", "Title");
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var comment = _unitOfWork.CommentRepository.Find(id.Value);
                if (comment != null)
                {
                    var commentVM = _mapper.Map<CommentVM>(comment);
                    ViewBag.PostId = new SelectList(_unitOfWork.PostRepository.GetAll(), "Id", "Title", comment.PostId);
                    return View(commentVM);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CommentVM commentVM)
        {
            if (ModelState.IsValid)
            {
                var comment = _mapper.Map<Comment>(commentVM);
                _unitOfWork.CommentRepository.Update(comment);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.PostId = new SelectList(_unitOfWork.PostRepository.GetAll(), "Id", "Title", commentVM.PostId);
            return View();
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _unitOfWork.CommentRepository.Delete(id);
            _unitOfWork.Save();
            return Json(new { status = true });
        }
    }
}
