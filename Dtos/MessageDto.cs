using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PosterrAPI.Dtos
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
    }
}
