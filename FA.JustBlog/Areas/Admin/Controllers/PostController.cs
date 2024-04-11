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
    public class PostController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var posts = _unitOfWork.PostRepository.GetAll().ToList();
            var postsVM = _mapper.Map<List<PostVM>>(posts);
            return View(postsVM);
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var post = _unitOfWork.PostRepository.Find(id.Value);
                if (post != null)
                {
                    var postVM = _mapper.Map<PostVM>(post);
                    ViewBag.AvailableTags = _unitOfWork.TagRepository.GetAll();
                    ViewBag.CategoryId = new SelectList(_unitOfWork.CategoryRepository.GetAll(), "Id", "Name");
                    return View(postVM);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PostVM postVM, List<int> Tags)
        {
            if (ModelState.IsValid)
            {
                // Get the existing post from the database
                var post = _unitOfWork.PostRepository.Find(postVM.Id);

                if (post == null)
                {
                    return NotFound();
                }

                // Map the updated PostVM to the Post entity
                _mapper.Map(postVM, post);

                // Clear the existing PostTagMaps
                post.PostTagMaps.Clear();

                // Add the new PostTagMaps
                foreach (var tagId in Tags)
                {
                    var postTagMap = new PostTagMap { PostId = post.Id, TagId = tagId };
                    post.PostTagMaps.Add(postTagMap);
                }

                // Save the changes
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.AvailableTags = _unitOfWork.TagRepository.GetAll();
            ViewBag.CategoryId = new SelectList(_unitOfWork.CategoryRepository.GetAll(), "Id", "Name");
            return View(postVM);
        }

        public IActionResult Create()
        {
            ViewBag.AvailableTags = _unitOfWork.TagRepository.GetAll();
            ViewBag.CategoryId = new SelectList(_unitOfWork.CategoryRepository.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PostVM postVM, List<int> Tags)
        {
            if (ModelState.IsValid)
            {
                var post = _mapper.Map<Post>(postVM);
                post.PostTagMaps = new List<PostTagMap>();
                foreach (var tagId in Tags)
                {
                    var postTagMap = new PostTagMap { PostId = post.Id, TagId = tagId };
                    post.PostTagMaps.Add(postTagMap);
                }
                _unitOfWork.PostRepository.Add(post);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            ViewBag.AvailableTags = _unitOfWork.TagRepository.GetAll();
            ViewBag.CategoryId = new SelectList(_unitOfWork.CategoryRepository.GetAll(), "Id", "Name");
            return View(postVM);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _unitOfWork.PostRepository.Delete(id);
            _unitOfWork.Save();
            return Json(new { status = true });
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                var post = _unitOfWork.PostRepository.Find(id.Value);
                if (post != null)
                {
                    var postVM = _mapper.Map<PostVM>(post);
                    return View(postVM);
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Latest()
        {
            ViewBag.Message = "Latest Posts";
            ViewBag.SortBy = "Latest";
            var latestPost = _unitOfWork.PostRepository.GetLatestPost(_unitOfWork.PostRepository.GetAll().Count()).ToList();
            var latestPostVM = _mapper.Map<List<PostVM>>(latestPost);
            return View("Index", latestPostVM);
        }

        public IActionResult MostViewed()
        {
            ViewBag.SortBy = "Most Viewed";
            var mostViewedPosts = _unitOfWork.PostRepository.GetMostViewedPost(_unitOfWork.PostRepository.GetAll().Count()).ToList();
            var mostViewedPostsVM = _mapper.Map<List<PostVM>>(mostViewedPosts);
            return View("Index", mostViewedPostsVM);
        }

        public IActionResult Published()
        {
            ViewBag.SortBy = "Published";
            var publishedPosts = _unitOfWork.PostRepository.GetPublishedPosts();
            var publishedPostsVM = _mapper.Map<List<PostVM>>(publishedPosts);
            return View("Index", publishedPostsVM);
        }

        public IActionResult Unpublished()
        {
            ViewBag.SortBy = "Unpublished";
            var unpublisedPosts = _unitOfWork.PostRepository.GetUnpublishedPosts().ToList();
            var unpublisedPostsVM = _mapper.Map<List<PostVM>>(unpublisedPosts);
            return View("Index", unpublisedPostsVM);
        }
    }
}
