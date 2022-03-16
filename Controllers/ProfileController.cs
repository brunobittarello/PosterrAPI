using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PosterrAPI.Dtos;
using PosterrAPI.Entities;
using PosterrAPI.Interfaces;
using PosterrAPI.Services;

namespace PosterrAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(IUserService userService, ILogger<ProfileController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Follow> Get(int page)
        {
            return _userService.GetFollowers(page);
        }

        [HttpPost]
        public ActionResult AddFollower(Guid id)
        {
            var result = _userService.AddFollow(id);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpDelete]
        public ActionResult Remove(Guid id)
        {
            var result = _userService.RemoveFollow(id);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}
