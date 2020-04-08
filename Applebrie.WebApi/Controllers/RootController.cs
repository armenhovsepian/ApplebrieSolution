﻿using Microsoft.AspNetCore.Mvc;

namespace Applebrie.WebApi.Controllers
{
    [Route("/")]
    //[ApiVersion("1.0")]
    public class RootController : Controller
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var resources = new
            {
                UserTypes = new
                {
                    href = Url.Link(nameof(UserTypesController.GetUserTypes), null)
                },

                Users = new 
                {
                    href = Url.Link(nameof(UsersController.GetUsers), null)
                }
                
               
            };
            return Ok(resources);
        }



        //[HttpGet("{id}", Name = nameof(GetRoot))]
        //public async Task<IActionResult> Get(int id, CancellationToken ct)
        //{
        //    await Task.CompletedTask;
        //    var res = new
        //    {
        //        //href = "url"
        //        href = Url.Link(nameof(GetRoot), null)
        //    };
        //    return Ok(res);
        //}

    }
}