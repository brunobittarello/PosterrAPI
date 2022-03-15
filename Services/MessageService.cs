using System.Collections.Generic;
using System.Linq;
using PosterrAPI.Dtos;
using PosterrAPI.Interfaces;

namespace PosterrAPI.Services
{
    public class MessageService : IMessageService
    {
        private readonly List<MessageDto> _messages;

        public MessageService()
        {
            _messages = new List<MessageDto>(Enumerable.Range(1, 200).Select(index => FakeMessage(index)));
        }

        public List<MessageDto> GetMessages(int page)
        {
            return _messages;
        }

        private MessageDto FakeMessage(int id)
        {
            return new MessageDto()
            {
                Id = id,
                Text = Faker.Lorem.Sentence(4),
                UserName = Faker.Name.First()
            };
        }
    }
}
