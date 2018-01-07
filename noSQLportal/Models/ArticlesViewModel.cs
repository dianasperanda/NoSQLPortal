using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace noSQLportal.Models
{
    public class ArticlesViewModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        //[Required]
        public string Comment { get; set; }

        public IFormFile Picture { get; set; }

        public List<Article> Articles = new List<Article>();
    }
}
