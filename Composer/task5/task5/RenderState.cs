using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public abstract class RenderState
    {
        public abstract string Render(LightElementNode node);
        public virtual Mood HandleInput(ConsoleKey key) => Mood.Neutral;
    }
}
