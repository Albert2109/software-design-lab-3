using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class ArtifactDecorator:HeroDecorator

    {
      
        public ArtifactDecorator(Hero hero):base(hero) { }

        public override string GetDescription()=> Hero.GetDescription()+" з артефактом";
        public override int GetPower()=> Hero.GetPower()+10;
        public override int GetHealth()=>Hero.GetHealth()+10;
    }
}
