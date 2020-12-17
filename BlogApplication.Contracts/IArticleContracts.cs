using BlogApplication.Core.Repository;
using BlogApplication.Entities;

namespace BlogApplication.Contracts
{
    public interface IArticleContracts : IRepository<Article>
    {
        public string Test();
        public string Message(string _message);
    }
}
