using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using noSQLportal.Models;
using System;

namespace noSQLportal.Repos
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly PortalContext _context = null;

        public ArticleRepository(IOptions<Settings> settings)
        {
            _context = new PortalContext(settings);
        }

        public List<Article> GetTenNewestArticles()
        {
            //var articles = _context.Articles.Find(Builders<Article>.Filter.Empty).Sort(Builders<Article>.Sort.Descending("_id")).Limit(10).ToListAsync();
            //var articles = _context.Articles.Find(new BsonDocument()).ToListAsync().GetAwaiter().GetResult();
            var articles = _context.Articles.Find(new BsonDocument()).SortByDescending(b => b.Id).Limit(10).ToListAsync().GetAwaiter().GetResult();
            return articles;
        }

        public async Task AddArticle(ArticlesViewModel item)
        {
            var newArticle = new Article()
            {
                Title = item.Title,
                Content = item.Content,
                Author = item.Author
            };

            await _context.Articles.InsertOneAsync(newArticle);
        }

        public async Task AddCommentOnArticle(ArticlesViewModel item)
        {
            try
            {
                await _context.Articles.UpdateOneAsync(
                Builders<Article>.Filter.Eq("title", item.Title),
                Builders<Article>.Update.Push("comments", item.Comment));
            }
            catch(Exception ex)
            {
                throw new NullReferenceException("Comment can not be null.");
            }
            
        }

        public async Task AddPictureOnArticle(ArticlesViewModel item)
        {
            using (var binaryReader = new BinaryReader(item.Picture.OpenReadStream()))
            {
                try
                {
                    var data = binaryReader.ReadBytes((int)item.Picture.Length);
                    await _context.Articles.UpdateOneAsync(
                        Builders<Article>.Filter.Eq("title", item.Title),
                        Builders<Article>.Update.Set("picture", data));
                }
                catch (Exception ex)
                {

                    throw new NullReferenceException("Picture can not be null.");
                }
                
            }
        }
    }
}
