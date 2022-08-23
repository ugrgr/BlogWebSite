using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using BlogWebSite.Models;
using BlogWebSite.Repositories;

namespace BlogWebSite.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {

        private readonly IBlogRepository _repository;

        public NotFoundFilter(IBlogRepository repository)
        {
            _repository = repository;
        }

        public override async void OnActionExecuting(ActionExecutingContext context)
        {
          var idValue=  context.ActionArguments.Values.FirstOrDefault();

            if(idValue==null)
            {
                return;
            }

            var id = Convert.ToInt32(idValue);
            var hasBlog = _repository.Any(x => x.Id == id);

            if(hasBlog==false)
            {

                context.Result = new RedirectToActionResult("Error", "Home", new ErrorViewModel() { Message = "Makale bulunamadı" });
            }

        }

    }
}
