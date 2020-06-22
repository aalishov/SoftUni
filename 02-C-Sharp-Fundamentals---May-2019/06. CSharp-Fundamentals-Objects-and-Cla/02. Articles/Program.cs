using System;

namespace _02._Articles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] info = Console.ReadLine().Split(',');
            int commandsNumber = int.Parse(Console.ReadLine());
            Article newArticle = new Article(info[0], info[1].TrimStart(), info[2].TrimStart());
            for (int i = 0; i < commandsNumber; i++)
            {
                string[] input = Console.ReadLine().Split(':');
                string edit = input[1].TrimStart();
                edit = edit.TrimEnd();
                switch (input[0])
                {
                    case "Edit":
                        newArticle.Edit(edit);
                        break;
                    case "ChangeAuthor":
                        newArticle.ChangeAuthor(edit);
                        break;
                    case "Rename":
                        newArticle.Rename(edit);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(newArticle.ToString());
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
        public void Edit(string newString)
        {
            this.Content = newString;
        }
        public void ChangeAuthor(string newString)
        {
            this.Author = newString;
        }
        public void Rename(string newString)
        {
            this.Title = newString;
        }
        public override string ToString()
        {
            return string.Format($"{Title} - {Content}: {Author}");
        }
    }
}
