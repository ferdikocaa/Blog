using BlogApplication.Contracts;
using BlogApplication.Core.Repository;
using BlogApplication.Entities;
using System;

namespace BlogApplication.Data.Repository
{
    public class ArticleRepository : BaseRepository<Article>,IArticleContracts
    {
        public ArticleRepository(AppDbContext context) : base(context) { }

        public string Message(string _message)
        {
             return _message;
        } 

        public string Test()
        {
            throw new NotImplementedException();
        }
    }
}
