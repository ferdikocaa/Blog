using BlogApplication.Core.Entities;
using System;
using System.Collections.Generic;

namespace BlogApplication.Entities
{
    public class Article : BaseEntities
    {
        public Article()
        {
            Articles = new List<Article>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Article> Articles { get; set; }
    }
}
