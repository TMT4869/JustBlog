using AutoMapper;
using FA.JustBlog.Core.Models.ViewModels;
using FA.JustBlog.Core.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace FA.JustBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private void SeedData()
        {
            var latestPosts = _unitOfWork.PostRepository.GetLatestPost(5).ToList();
            var latestPostsVM = _mapper.Map<List<PostVM>>(latestPosts);
            ViewBag.SortByLatest = latestPostsVM;

            var mostViewedPosts = _unitOfWork.PostRepository.GetMostViewedPost(5).ToList();
            var mostViewedPostsVM = _mapper.Map<List<PostVM>>(mostViewedPosts);
            ViewBag.MostViewedPosts = mostViewedPostsVM;

            var popularTags = _unitOfWork.TagRepository.GetAll().OrderByDescending(x => x.Count).Take(10).ToList();
            var popularTagsVM = _mapper.Map<List<TagVM>>(popularTags);
            ViewBag.PopularTags = popularTagsVM;

            var availableTags = _unitOfWork.TagRepository.GetAll();
            var availableTagsVM = _mapper.Map<List<TagVM>>(availableTags);
            ViewBag.AvailableTags = availableTagsVM;
        }
        public IActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = HttpContext.Session.GetInt32("PageSize") ?? 3;
            ViewBag.CurrentPage = page;
            var posts = _unitOfWork.PostRepository.GetAll();
            var postsVM = _mapper.Map<List<PostVM>>(posts);
            ViewBag.TotalItems = postsVM.Count;
            ViewBag.Title = "All Posts";
            SeedData();
            return View(postsVM.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult LatestPost()
        {
            var latestPosts = _unitOfWork.PostRepository.GetLatestPost(5).ToList();
            var latestPostsVM = _mapper.Map<List<PostVM>>(latestPosts);
            return PartialView("_ListPosts", latestPostsVM);
        }

        public IActionResult MostViewedPosts()
        {
            var mostViewedPosts = _unitOfWork.PostRepository.GetMostViewedPost(5).ToList();
            var mostViewedPostsVM = _mapper.Map<List<PostVM>>(mostViewedPosts);
            return PartialView("_ListPosts", mostViewedPostsVM);
        }

        public IActionResult Category(string name, int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = HttpContext.Session.GetInt32("PageSize") ?? 1;
            var posts = _unitOfWork.PostRepository.GetPostsByCategory(name);
            var postsVM = _mapper.Map<List<PostVM>>(posts);
            ViewBag.TotalItems = postsVM.Count;
            ViewBag.Title = $"All Posts In Category {name}";
            SeedData();
            return View("Index", postsVM.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Tag(string name, int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = HttpContext.Session.GetInt32("PageSize") ?? 1;
            var posts = _unitOfWork.PostRepository.GetPostsByTag(name).ToList();
            var postsVM = _mapper.Map<List<PostVM>>(posts);
            ViewBag.TotalItems = postsVM.Count;
            ViewBag.Title = $"All Posts With Tag \"{name}\"";
            SeedData();
            return View("Index", postsVM.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Details(int year, int month, string title)
        {
            var post = _unitOfWork.PostRepository.FindPost(year, month, title);
            if (post == null)
            {
                return NotFound();
            }
            var postVM = _mapper.Map<PostVM>(post);
            var comments = _unitOfWork.CommentRepository.GetCommentsForPost(post.Id);
            var commentsVM = _mapper.Map<List<CommentVM>>(comments);
            ViewBag.Comments = commentsVM;
            return View(postVM);
        }

        public IActionResult Categories()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll().ToList();
            var categoriesVM = _mapper.Map<List<CategoryVM>>(categories);
            return PartialView("_Categories", categoriesVM);
        }

        [HttpPost]
        public IActionResult SetPageSize(int pageSize, int currentPage, string currentUrl, int totalItems)
        {
            // Store the page size in session
            HttpContext.Session.SetInt32("PageSize", pageSize);

            // Get the total items from ViewBag
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            // Parse the current URL
            var uriBuilder = new UriBuilder(currentUrl);
            var query = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(uriBuilder.Query);
            // Convert the query to a mutable dictionary
            var queryDict = query.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString());
            // Remove the 'pageSize' parameter from the dictionary
            queryDict.Remove("pageSize");
            // If total pages is 1, remove the 'page' parameter
            if (totalPages == 1)
            {
                queryDict.Remove("page");
            }
            else
            {
                // Update the 'page' parameter
                queryDict["page"] = currentPage.ToString();
            }
            // Convert the query dictionary back to a string
            string queryString = Microsoft.AspNetCore.WebUtilities.QueryHelpers.AddQueryString("", queryDict);
            // Set the updated query string
            uriBuilder.Query = queryString;
            // Redirect back to the current page
            return Redirect(uriBuilder.ToString());
        }
    }
}
