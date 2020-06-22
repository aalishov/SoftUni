using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private ICollection<IDwarf> dwarfs = new List<IDwarf>();
        private ICollection<IPresent> presents = new List<IPresent>();

        
        public string AddDwarf(string dwarfType, string dwarfName)
        {
            if (dwarfType != "HappyDwarf" && dwarfType != "SleepyDwarf")
            {
                throw new InvalidDataException(ExceptionMessages.InvalidDwarfType);
            }
            else if (dwarfType == "HappyDwarf")
            {
                var dwarf = new HappyDwarf(dwarfName);
                dwarfs.Add(dwarf);

            }
            else if (dwarfType == "SleepyDwarf")
            {
                var dwarf = new SleepyDwarf(dwarfName);
                dwarfs.Add(dwarf);
            }

            return $"Successfully added {dwarfType} named {dwarfName}.";
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            var dwarf = dwarfs.FirstOrDefault(x => x.Name == dwarfName);
            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }

            dwarf.AddInstrument(new Instrument(power));
            return string.Format(OutputMessages.InstrumentAdded, power, dwarf.Name);
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            presents.Add(new Present(presentName, energyRequired));
            return string.Format(OutputMessages.PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {
            dwarfs.OrderByDescending(x => x.Energy);
            var currentDwarf = dwarfs.FirstOrDefault(x => x.Energy >= 50);
            var currentPresent = presents.FirstOrDefault(z => z.Name == presentName);

            if (currentDwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            while (currentDwarf.Energy != 0)
            {
                currentDwarf.Work();
                currentPresent.GetCrafted();
            }

            dwarfs.Remove(currentDwarf);
            if (currentPresent.EnergyRequired != 0)
            {
                return $"Present {presentName} is not done.";
            }
            return $"Present {presentName} is done.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{presents.Count} presents are done!");

            foreach (var dwarf in dwarfs)
            {
                sb.AppendLine($"Dwarfs info:")
                    .AppendLine($"{dwarf.Name}")
                    .AppendLine($"Energy: {dwarf.Energy}")
                    .AppendLine($"Instruments: {dwarf.Instruments.Count} not broken left.");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
