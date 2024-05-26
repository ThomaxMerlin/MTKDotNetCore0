using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;

namespace QuotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private static List<Quote> Quotes = new List<Quote>
        {
            // Initialize with the provided quotes data
            new Quote { Id = Guid.Parse("adcf23fa-b579-4215-85c2-2c0f3f4beee2"), UserId = 1, Quotes = "action is fundamental key, to all success", ImageUrl = "img\\1\\action is fundamental key, to all success.jpg" },
            // Add the remaining quotes here...
        };

        [HttpGet]
        public ActionResult<IEnumerable<Quote>> GetAllQuotes()
        {
            return Ok(Quotes);
        }

        [HttpGet("{id}")]
        public ActionResult<Quote> GetQuoteById(Guid id)
        {
            var quote = Quotes.FirstOrDefault(q => q.Id == id);
            if (quote == null)
            {
                return NotFound();
            }
            return Ok(quote);
        }

        [HttpPost]
        public ActionResult<Quote> CreateQuote(Quote newQuote)
        {
            newQuote.Id = Guid.NewGuid();
            Quotes.Add(newQuote);
            return CreatedAtAction(nameof(GetQuoteById), new { id = newQuote.Id }, newQuote);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateQuote(Guid id, Quote updatedQuote)
        {
            var quote = Quotes.FirstOrDefault(q => q.Id == id);
            if (quote == null)
            {
                return NotFound();
            }

            quote.UserId = updatedQuote.UserId;
            quote.Quotes = updatedQuote.Quotes;
            quote.ImageUrl = updatedQuote.ImageUrl;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteQuote(Guid id)
        {
            var quote = Quotes.FirstOrDefault(q => q.Id == id);
            if (quote == null)
            {
                return NotFound();
            }

            Quotes.Remove(quote);
            return NoContent();
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<User> Users = new List<User>
        {
            new User { UserId = 1, UserName = "", FullName = "", Links = new List<Link> { new Link { Name = "instagram", Url = "" } } },
            new User { UserId = 2, UserName = "", FullName = "", Links = new List<Link> { new Link { Name = "instagram", Url = "" } } },
        };

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return Ok(Users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = Users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> CreateUser(User newUser)
        {
            Users.Add(newUser);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.UserId }, newUser);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, User updatedUser)
        {
            var user = Users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            user.UserName = updatedUser.UserName;
            user.FullName = updatedUser.FullName;
            user.Links = updatedUser.Links;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = Users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            Users.Remove(user);
            return NoContent();
        }
    }
}
