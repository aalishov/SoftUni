using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    static void Main(string[] args)
    {
        int numberOfMoovies = int.Parse(Console.ReadLine());
        List<Moovie> movies = new List<Moovie>();

        for (int i = 0; i < numberOfMoovies; i++)
        {
            string moovieName = Console.ReadLine();
            double movieRating = double.Parse(Console.ReadLine());
            movies.Add(new Moovie(moovieName, movieRating));
        }
        Moovie moovieTopRating = movies.LastOrDefault(x=>x.Rating==movies.Max(m=>m.Rating));
        Moovie moovieBottomRating = movies.LastOrDefault(x => x.Rating == movies.Min(m => m.Rating));
        double moovieAverageRating = movies.Average(x => x.Rating);

        Console.WriteLine($"{moovieTopRating.Name} is with highest rating: {moovieTopRating.Rating:f1}");
        Console.WriteLine($"{moovieBottomRating.Name} is with lowest rating: {moovieBottomRating.Rating:f1}");
        Console.WriteLine($"Average rating: {moovieAverageRating:f1}");
    }
       
}
public class Moovie
{
    public Moovie(string name, double rating)
    {
        this.Name = name;
        this.Rating = rating;
    }
    public string Name { get; set; }
    public double Rating { get; set; }
}

