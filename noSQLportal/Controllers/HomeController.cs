using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using noSQLportal.Models;
using noSQLportal.Repos;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace noSQLportal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleRepository _articleRepository;

        public HomeController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public IActionResult Index()
        {
            var news = new ArticlesViewModel()
            {
                Articles = _articleRepository.GetTenNewestArticles()
            };

            return View(news);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult AddNewArticle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewArticle(ArticlesViewModel articlesViewModel)
        {
            if (ModelState.IsValid)
                _articleRepository.AddArticle(articlesViewModel);

            return RedirectToAction("Index");
        }

        public IActionResult AddComment(ArticlesViewModel articlesViewModel)
        {
            if (ModelState.IsValid)
                _articleRepository.AddCommentOnArticle(articlesViewModel);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPicture(ArticlesViewModel articlesViewModel)
        {
            if (ModelState.IsValid)
                await _articleRepository.AddPictureOnArticle(articlesViewModel);

            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }        
    }
}
