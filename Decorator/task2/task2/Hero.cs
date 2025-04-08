using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
   public abstract class Hero:IHero
    {
        public abstract string GetDescription();
        public abstract int GetPower();
        public abstract int GetHealth();
    }
}
