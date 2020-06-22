using System;

namespace _01._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Message m = new Message();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(m.ToString());
            }
        }
    }
    public class  Message
    {
        private string[] arrPhrases = new string[] { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
        private string[] arrEvents = new string[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
        private string[] arrAurthors = new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
        private string[] arrCities = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };
        public string Phrases { get; set; }
        public string Events { get; set; }
        public string Authors { get; set; }
        public string Cities { get; set; }

        public int RandomIndex(string[] arr)
        {
            Random random = new Random();
            return random.Next(0, arr.Length - 1);
        }
        public int[] ArrRandomIndex()
        {
            int[] index = new int[4];
            index[0] = RandomIndex(arrPhrases);
            index[1] = RandomIndex(arrEvents);
            index[2] = RandomIndex(arrAurthors);
            index[3] = RandomIndex(arrCities);
            return index;
        }
        public override string ToString()
        {
            int[] r = ArrRandomIndex();
            return string.Format($"{arrPhrases[r[0]]} {arrEvents[r[1]]} {arrAurthors[r[2]]} – {arrCities[r[3]]}."); 
        }
    }
}
