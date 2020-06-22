using System;
using System.Collections.Generic;
using System.Text;
using PizzaCalories.Enumerators;
namespace PizzaCalories
{
    public class Topping
    {
        private const double caloriesPerGram = 2;
        private const double mMeat = 1.2;
        private const double mVeggies = 0.8;
        private const double mCheese = 1.1;
        private const double mSauce = 0.9;

        private double weight;
        private double calories;
        private ToppingType toppingType;

        public Topping(string toppingType, double weight)
        {
            this.Weight = weight;
            this.ToppingType = toppingType;
            this.Calories = CalculateCalories();
        }

        public double Calories
        {
            get { return calories; }
            private set { calories = value; }
        }
        public string ToppingType
        {
            get { return toppingType.ToString(); }
            private set
            {
                if (!Enum.IsDefined(typeof(Enumerators.ToppingType), value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = Enum.Parse<ToppingType>(value.ToLower());
            }
        }

        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.toppingType} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }


        private double CalculateCalories()
        {
            double modifier = ModifiereValue();
            return this.weight * modifier * caloriesPerGram;
        }
        private double ModifiereValue()
        {
            double modifier = 0.0;
            switch (this.toppingType)
            {
                case (Enumerators.ToppingType)0:
                    modifier = mMeat;
                    break;
                case (Enumerators.ToppingType)1:
                    modifier = mVeggies;
                    break;
                case (Enumerators.ToppingType)2:
                    modifier = mCheese;
                    break;
                case (Enumerators.ToppingType)3:
                    modifier = mSauce;
                    break;
            }
            return modifier;
        }
    }
}
