using AutoMapper;
using FA.JustBlog.Core.Models.ViewModels;
using FA.JustBlog.Core.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers
{
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
            return View();
        }

        public IActionResult PopularTags()
        {
            var popularTags = _unitOfWork.TagRepository.GetAll().OrderByDescending(x => x.Count).Take(10).ToList();
            var popularTagsVM = _mapper.Map<List<TagVM>>(popularTags);
            return PartialView("_PopularTags", popularTagsVM);
        }
    }
}
