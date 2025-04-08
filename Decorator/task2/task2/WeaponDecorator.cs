using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class WeaponDecorator:HeroDecorator
    {
      
        public WeaponDecorator(Hero hero):base(hero) { }

        public override string GetDescription() => Hero.GetDescription() + " зі зброєю";
        public override int GetPower() => Hero.GetPower()+15;

        public override int GetHealth() =>Hero.GetHealth();
       




    }
}
