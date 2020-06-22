using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite.Interfaces
{
    public interface ILieutenantGeneral:IPrivate
    {
        public List<IPrivate> Privates { get; set; }
    }
}
