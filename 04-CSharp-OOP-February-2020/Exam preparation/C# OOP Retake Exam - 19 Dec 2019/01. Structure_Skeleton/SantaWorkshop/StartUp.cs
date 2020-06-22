namespace SantaWorkshop
{
    using System;

    using SantaWorkshop.Core;
    using SantaWorkshop.Core.Contracts;
    using SantaWorkshop.Models.Dwarfs;

    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();



        }
    }
}
