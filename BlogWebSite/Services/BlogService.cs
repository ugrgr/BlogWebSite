using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using BlogWebSite.Models;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using BlogWebSite.Repository;
using BlogWebSite.Core.Models;

namespace BlogWebSite.Services
{
    public class BlogService : IBlogService
    {

        private readonly HttpClient _client;
        private readonly ILogger<BlogService> _logger;
        private readonly AppDbContext _context;

        public BlogService(HttpClient client, ILogger<BlogService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public void BlogCreateViewModel(BlogCreateModel blogCreate)
        {
            throw new NotImplementedException();
        }

        public void BlogUpdateViewModel(BlogUpdateViewModel blogUpdate)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> Create(BlogCreateModel request)
        {

         return  await _client.PostAsJsonAsync<BlogCreateModel>("Blog/create", request);

        }
        public async Task<HttpResponseMessage> Update(BlogUpdateModel request)
        {
            return await _client.PostAsJsonAsync<BlogUpdateModel>("Blog/update", request);
        }
        public async Task<List<BlogViewModel>> GetAll()
        {
            var response = await _client.GetFromJsonAsync<Response<List<BlogViewModel>>>("Blog/list");

            if (response.Data != null)
            {
                return response.Data;
            }

            foreach (var item in response.Errors)
            {
                _logger.LogError(item);
            }
            throw new Exception("İşlem gerçekleşirken bir hata meydana geldi.");
        }

        public async Task<List<CategoryViewModel>> GetCategories()
        {
            var response = await _client.GetFromJsonAsync<Response<List<CategoryViewModel>>>("Blog/getcategories");

            if (response.Data != null)
            {
                return response.Data;
            }

            foreach (var item in response.Errors)
            {
                _logger.LogError(item);
            }
            throw new Exception("İşlem gerçekleşirken bir hata meydana geldi.");
        }
        public async Task<BlogUpdateModel> GetById(int id)
        {
            var response = await _client.GetFromJsonAsync<Response<BlogUpdateModel>>($"Blog/{id}");
            return response.Data;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _client.DeleteAsync($"Blog/delete/{id}");
            return response.StatusCode==HttpStatusCode.NoContent;
        }

    }
}

