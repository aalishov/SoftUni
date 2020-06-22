using System;
using System.Collections.Generic;
using System.Text;

namespace P05_BirthdayCelebrations
{
    public abstract class Inhabitant
    {
        public string Id { get; set; }

        public bool IsDetained(string fakeId)
        {
            if (this.Id.Contains(fakeId))
            {
                int starIndex = this.Id.LastIndexOf(fakeId);
                if (starIndex+fakeId.Length==this.Id.Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{this.Id}";
        }
    }
}
