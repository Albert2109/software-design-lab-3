using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public abstract class HeroDecorator:Hero
    {
        protected Hero Hero;
        public HeroDecorator(Hero hero)
        {
            this.Hero = hero;
        }
        public override string GetDescription() => Hero.GetDescription();
        public override int GetPower() => Hero.GetPower();
        public override int GetHealth()=> Hero.GetHealth();
    }

}
