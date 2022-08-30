
using BlogWebSite.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlogWebSite.Services
{
    public interface IBlogService
    {
        Task<List<BlogViewModel>> GetAll();
        Task<HttpResponseMessage> Create(BlogCreateModel request);
        Task<List<CategoryViewModel>> GetCategories();
        void BlogCreateViewModel(BlogCreateModel blogCreate);
        Task<HttpResponseMessage> Update(BlogUpdateModel request);
        void BlogUpdateViewModel(BlogUpdateViewModel blogUpdate);

        Task<BlogUpdateModel> GetById(int id);

        Task<bool> Delete(int id);

    }
}
