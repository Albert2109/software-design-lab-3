using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Palladin:Hero
    {
        public override string GetDescription() => "Паладін";
        public override int GetPower() => 110;
        public override int GetHealth() => 90;
    }
}
