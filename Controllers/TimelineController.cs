using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PosterrAPI.Dtos;
using PosterrAPI.Interfaces;
using PosterrAPI.Services;

namespace PosterrAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimelineController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly ILogger<TimelineController> _logger;

        public TimelineController(IPostService postService, ILogger<TimelineController> logger)
        {
            _postService = postService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<PostDto> GetAll(int page)
        {
            return _postService.GetPosts(page, TimelineSubject.All);
        }

        [HttpGet("followers")]
        public IEnumerable<PostDto> GetFollowers(int page)
        {
            return _postService.GetPosts(page, TimelineSubject.Followers);
        }

        [HttpGet("user")]
        public IEnumerable<PostDto> GetUser(int page)
        {
            return _postService.GetPosts(page, TimelineSubject.User);
        }

        [HttpPost]
        public ActionResult Post(string message)
        {
            var result = _postService.CreatePost(message);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpPost("quote")]
        public ActionResult PostQuote(Guid id, string message)
        {
            var result = _postService.CreateQuote(id, message);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpPost("repost")]
        public ActionResult PostRepost(Guid id)
        {
            var result = _postService.CreateRepost(id);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}
