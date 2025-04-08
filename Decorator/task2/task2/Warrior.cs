using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
   public class Warrior:Hero
    {
        public override string GetDescription() => "Воїн";
        public override int GetPower() => 80;
        public override int GetHealth() => 100;
    }
}
