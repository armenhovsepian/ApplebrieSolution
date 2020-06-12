using Applebrie.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Applebrie.WebApi.Filters
{
    /// <summary>
    /// https://code-maze.com/action-filters-aspnetcore/
    /// https://docs.microsoft.com/en-us/archive/msdn-magazine/2016/august/asp-net-core-real-world-asp-net-core-mvc-filters
    /// </summary>
    public class ValidateUserTypeExists : ActionFilterAttribute
    {
        private readonly IUserTypeRepository _userTypeRepository;
        public ValidateUserTypeExists(IUserTypeRepository userTypeRepository) =>
            _userTypeRepository = userTypeRepository;


        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ActionArguments.ContainsKey("id"))
            {
                var id = (int)context.ActionArguments["id"];
                var cancellationToken = context.HttpContext.RequestAborted;
                var userType = await _userTypeRepository.GetByIdAsync(id, cancellationToken);
                if (userType != null)
                {
                    await next(); 
                    return;
                }
            }

            context.Result = new NotFoundResult();

        }
    }
}
