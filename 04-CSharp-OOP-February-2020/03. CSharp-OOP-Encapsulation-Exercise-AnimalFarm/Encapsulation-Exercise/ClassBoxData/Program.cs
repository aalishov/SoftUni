using System;

namespace ClassBoxData
{
    public class Program
    {
        public static void Main()
        {
            double l = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            try
            {
                Box box = new Box(l, w, h);
                Console.WriteLine(box.SurfaceArea());
                Console.WriteLine(box.LateralArea());
                Console.WriteLine(box.Volume());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
    

        }
    }
}
