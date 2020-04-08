
using Microsoft.AspNetCore.Mvc;

namespace Applebrie.WebApi.Controllers
{
    [Route("/")]
    [ApiVersion("1.0")]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var resources = new
            {
                href = Url.Link(nameof(GetRoot), null),

                UserTypes = new
                {
                    href = Url.Link(nameof(UserTypesController.GetUserTypesAsync), null)
                },

                Users = new
                {
                    href = Url.Link(nameof(UsersController.GetUsersAsync), null)
                }

            };

            return Ok(resources);
        }
    }
}