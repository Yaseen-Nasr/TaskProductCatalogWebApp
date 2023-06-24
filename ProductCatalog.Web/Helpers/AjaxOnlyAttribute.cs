using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ProductCatalog.Web.Helpers
{
    public class AjaxCallAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers["X-Requested-With"].ToString().Equals("XMLHttpRequest"))
            {
                context.Result = new BadRequestObjectResult("Only Ajax requests are allowed.");
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
