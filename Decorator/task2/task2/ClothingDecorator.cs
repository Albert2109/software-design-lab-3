using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class ClothingDecorator:HeroDecorator
    {
        
        public ClothingDecorator(Hero Hero):base(Hero) { }
        public override string GetDescription() => Hero.GetDescription() + " у броні";
        public override int GetHealth() => Hero.GetHealth()+20;
        public override int GetPower() =>Hero.GetPower();
        
          
        




    }
}
