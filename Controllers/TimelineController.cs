using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PosterrAPI.Dtos;

namespace PosterrAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimelineController : ControllerBase
    {
        private readonly ILogger<TimelineController> _logger;

        public TimelineController(ILogger<TimelineController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<MessageDto> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => FakeMessage())
            .ToArray();
        }

        public MessageDto FakeMessage()
        {
            return new MessageDto() {
              Id = 0,
              Text = Faker.Lorem.Sentence(4),
              UserName = Faker.Name.First()
            };
        }
    }
}
