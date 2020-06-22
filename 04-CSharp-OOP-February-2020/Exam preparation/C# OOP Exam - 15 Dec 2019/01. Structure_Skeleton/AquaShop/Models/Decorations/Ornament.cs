namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int OrnamentComfort = 1;
        private const decimal OranmentPrice = 5m;
        public Ornament()
            : base(OrnamentComfort, OranmentPrice)
        {
        }
    }
}
