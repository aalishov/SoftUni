using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }
        public void Craft(IPresent present, IDwarf dwarf)
        {
            while (!present.IsDone()&&dwarf.Instruments.Any(x=>!x.IsBroken()))
            {
                present.GetCrafted();
                dwarf.Instruments.FirstOrDefault(x => x.IsBroken() == false).Use();
            }
        }
    }
}
