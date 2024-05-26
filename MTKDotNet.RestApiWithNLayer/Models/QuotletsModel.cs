using System;
using System.Collections.Generic;

namespace QuotesApi.Models
{
    public class Quote
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string Quotes { get; set; }
        public string ImageUrl { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public List<Link> Links { get; set; }
    }

    public class Link
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
