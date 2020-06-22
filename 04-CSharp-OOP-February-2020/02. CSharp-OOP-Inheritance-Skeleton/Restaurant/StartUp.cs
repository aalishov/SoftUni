namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Fish fish = new Fish("ribka", 5);
            System.Console.WriteLine(fish.Grams);
        }
    }
}