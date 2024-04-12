using AutoMapper;
using FA.JustBlog.Core.Models.ViewModels;
using FA.JustBlog.Core.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HomeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Route("Admin")]
        [Route("Admin/Home")]
        public IActionResult Index()
        {
            var posts = _unitOfWork.PostRepository.GetAll().ToList();
            var postsVM = _mapper.Map<List<PostVM>>(posts);
            return View(postsVM);
        }
    }
}
