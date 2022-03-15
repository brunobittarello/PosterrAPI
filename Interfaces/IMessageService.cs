using System.Collections.Generic;
using PosterrAPI.Dtos;

namespace PosterrAPI.Interfaces
{
    public interface IMessageService
    {
        public List<MessageDto> GetMessages(int page);
    }
}