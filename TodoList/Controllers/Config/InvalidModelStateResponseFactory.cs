using Microsoft.AspNetCore.Mvc;
using TodoList.Extensions;
using TodoList.Resources;

namespace TodoList.Controllers.Config
{
    public static class InvalidModelStateResponseFactory
    {
         public static IActionResult ProduceErrorResponse(ActionContext context)
         {
             var errors = context.ModelState.GetErrorMessages();
             var response = new ErrorResource(messages: errors);

             return new BadRequestObjectResult(response);
         }
    }
}
