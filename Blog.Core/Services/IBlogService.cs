using BlogWebSite.Core.DTOs;
using BlogWebSite.Core.Models;

namespace BlogWebSite.Core.Services
{
    public interface IBlogService
    {
        CustomResponse<List<Blog>> GetAll();

        CustomResponse<BlogDto> Create(BlogCreateDto request);

        CustomResponse<string> Delete(int id);

        CustomResponse<List<Category>> GetCategories();

        CustomResponse<Blog> GetById(int id);

        CustomResponse<BlogUpdateDto> Update(BlogUpdateDto request);

    }
}
