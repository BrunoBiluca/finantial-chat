using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ChatAPI.Controllers {
    [Route("api/chat-messages")]
    public class ChatMessagesController : Controller {
        [HttpGet]
        public IEnumerable<ChatMessage> Get() {
            var mongoDbContext = new MongoDbContext();
            return mongoDbContext
                .ChatMessages
                .Find(FilterDefinition<ChatMessage>.Empty)
                .Limit(50)
                .SortByDescending(message => message.CreatedAt)
                .ToEnumerable();
        }
    }
}
