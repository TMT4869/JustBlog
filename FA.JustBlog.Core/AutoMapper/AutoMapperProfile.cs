using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Models.ViewModels;

namespace FA.JustBlog.Core.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public static IMapper Initialize()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Post, PostVM>()
                    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                    .ForMember(dest => dest.PostTagMaps, opt => opt.MapFrom(src => src.PostTagMaps
                        .Where(ptm => ptm.PostId == src.Id)
                        .Select(ptm => new PostTagMap
                        {
                            PostId = ptm.PostId,
                            TagId = ptm.TagId
                        }
                    )));

                config.CreateMap<PostVM, Post>();

                config.CreateMap<Category, CategoryVM>();
                config.CreateMap<CategoryVM, Category>();

                config.CreateMap<Tag, TagVM>();
                config.CreateMap<TagVM, Tag>();

                config.CreateMap<Comment, CommentVM>()
                    .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(src => src.Post.Title));
                config.CreateMap<CommentVM, Comment>();

                config.CreateMap<ApplicationUser, UserVM>();
                config.CreateMap<UserVM, ApplicationUser>();
            });
            return mapperConfig.CreateMapper();
        }
    }
}
