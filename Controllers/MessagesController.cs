using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MessageBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private MessageBoardContext _db;

        public MessagesController(MessageBoardContext db)
        {
            _db = db;
        }

        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Message>> Get()
        {
            return _db.Messages.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Message> Get(int id)
        {
            Message myMessage = _db.Messages.FirstOrDefault(text => text.MessageId == id);
            return myMessage;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Message myMessage)
        {
            _db.Messages.Add(myMessage);
            _db.SaveChanges();
        }

        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Message myMessage)
        {
            myMessage.MessageId = id;
            _db.Entry(myMessage).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var delete = _db.Messages.FirstOrDefault(text => text.MessageId == id);
            _db.Messages.Remove(delete);
            _db.SaveChanges();
        }
    }
}
