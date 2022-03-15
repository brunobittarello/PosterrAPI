using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PosterrAPI.Dtos;
using PosterrAPI.Interfaces;

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
        public IEnumerable<PostDto> Get(int page)
        {
            return _postService.GetPosts(page);
        }

        
    }
}
