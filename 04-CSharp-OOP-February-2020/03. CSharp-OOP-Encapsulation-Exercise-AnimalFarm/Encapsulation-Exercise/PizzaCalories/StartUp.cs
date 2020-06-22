using System;
using PizzaCalories.Enumerators;

namespace PizzaCalories
{
    public class StartUp
    {
        public static void Main()
        {

            try
            {
                string[] pizzaInfo = Console.ReadLine().Split(' ');
                string[] doughInfo = Console.ReadLine().Split(' ');

                Pizza pizza = new Pizza(pizzaInfo[1]);
                pizza.Dough = new Dough(double.Parse(doughInfo[3]), doughInfo[1], doughInfo[2]);
                while (true)
                {
                    string[] topingInfo = Console.ReadLine().Split(' ');
                    if (topingInfo[0] == "END")
                    {
                        Console.WriteLine(pizza);
                        break;
                    }
                    Topping topping = new Topping(topingInfo[1],int.Parse(topingInfo[2]));
                    if (topingInfo != null)
                    {
                        pizza.AddTopping(topping);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
