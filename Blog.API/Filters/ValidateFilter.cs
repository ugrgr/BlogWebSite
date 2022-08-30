using BlogWebSite.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlogWebSite.API.Filters
{
    public class ValidateFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();


                var response = CustomResponse<string>.Fail(errors);

                context.Result = new BadRequestObjectResult(response);



            }




            base.OnActionExecuting(context);
        }
    }
}
