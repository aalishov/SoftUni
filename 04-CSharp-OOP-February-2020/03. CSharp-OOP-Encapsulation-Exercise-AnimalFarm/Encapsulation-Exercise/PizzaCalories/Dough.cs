using PizzaCalories.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double caloriesPerGram = 2;
        private const double mWhite = 1.5;
        private const double mWholegrain = 1.0;
        private const double mCrispy = 0.9;
        private const double mChewy = 1.1;
        private const double mHomemade = 1.0;


        private double weight;
        private double calories;
        private FlourType flourType;
        private BakingTechnique bakingTechnique;

        public Dough(double weight, string flourType, string bakingTechnique)
        {
            this.Weight = weight;
            this.BakingTechnique = bakingTechnique;
            this.FlourType = flourType;
            this.Calories = CalculateCalories();
        }
        public string BakingTechnique
        {
            get { return bakingTechnique.ToString(); }
            private set
            {
                if (!Enum.IsDefined(typeof(BakingTechnique), value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = Enum.Parse<BakingTechnique>(value.ToLower());
            }
        }

        public string FlourType
        {
            get { return this.flourType.ToString(); }
            private set
            {
                if (!Enum.IsDefined(typeof(FlourType), value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = Enum.Parse<FlourType>(value.ToLower());
            }
        }


        public double Calories
        {
            get { return this.calories; }
            private set
            {
                this.calories = value;
            }
        }

        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value <1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }


        private double CalculateCalories()
        {
            double modifierFlourType = ModifierFlourTypeValue();
            double modifierBakingTechnique = ModifierBakingTechniqueValue();
            return this.weight * caloriesPerGram * modifierFlourType * modifierBakingTechnique;
        }

        private double ModifierFlourTypeValue()
        {
            double modifier = 0.0;
            switch (this.flourType)
            {
                case (Enumerators.FlourType)0:
                    modifier = mWhite;
                    break;
                case (Enumerators.FlourType)1:
                    modifier = mWholegrain;
                    break;
            }

            return modifier;
        }

        private double ModifierBakingTechniqueValue()
        {
            double modifier = 0.0;
            switch (this.bakingTechnique)
            {
                case (Enumerators.BakingTechnique)0:
                    modifier = mCrispy;
                    break;
                case (Enumerators.BakingTechnique)1:
                    modifier = mChewy;
                    break;
                case (Enumerators.BakingTechnique)2:
                    modifier = mHomemade;
                    break;
            }
            return modifier;
        }
    }
}
