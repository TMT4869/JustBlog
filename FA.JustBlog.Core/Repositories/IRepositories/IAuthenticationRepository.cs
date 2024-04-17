using FA.JustBlog.Core.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace FA.JustBlog.Core.Repositories.IRepositories
{
    public interface IAuthenticationRepository
    {
        Task<IdentityResult> Register(RegisterVM registerVM);
        Task<AuthResultVM> Login(LoginVM loginVM);
    }
}
