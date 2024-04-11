using FA.JustBlog.Core.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

public class CategoriesViewComponent : ViewComponent
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoriesViewComponent(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IViewComponentResult Invoke()
    {
        var categories = _unitOfWork.CategoryRepository.GetAll().ToList();
        return View(categories);
    }
}

