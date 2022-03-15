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
        private readonly IMessageService _messageService;
        private readonly ILogger<TimelineController> _logger;

        public TimelineController(IMessageService messageService, ILogger<TimelineController> logger)
        {
            _messageService = messageService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<MessageDto> Get(int page)
        {
            return _messageService.GetMessages(page);
        }

        
    }
}
