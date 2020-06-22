using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandsNumber = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            for (int i = 0; i < commandsNumber; i++)
            {
                string[] info = Console.ReadLine().Split(',');
                Article newArticle = new Article(info[0], info[1].TrimStart(), info[2].TrimStart());
                articles.Add(newArticle);
            }
            string command = Console.ReadLine();
            switch (command)
            {
                case "content":
                    articles
                        .OrderBy(x => x.Content)
                        .ToList()
                        .ForEach(x => Console.WriteLine(x.ToString()));
                    break;
                case "title":
                    articles
                        .OrderBy(x => x.Title)
                        .ToList()
                        .ForEach(x => Console.WriteLine(x.ToString()));
                    break;
                case "author":
                    articles
                        .OrderBy(x => x.Author)
                        .ToList()
                        .ForEach(x => Console.WriteLine(x.ToString()));
                    break;
            }

        }
    }
    public class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }        
        public override string ToString()
        {
            return string.Format($"{Title} - {Content}: {Author}");
        }
    }
}
