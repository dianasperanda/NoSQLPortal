using noSQLportal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace noSQLportal.Repos
{
    public interface IArticleRepository
    {
        List<Article> GetTenNewestArticles();

        Task AddArticle(ArticlesViewModel item);

        Task AddCommentOnArticle(ArticlesViewModel articlesViewModel);

        Task AddPictureOnArticle(ArticlesViewModel articlesViewModel);
    }
}
