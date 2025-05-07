using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class NeutralState : RenderState
    {
        public override string Render(LightElementNode node) => node.OuterHTML;

        public override Mood HandleInput(ConsoleKey key) => key switch
        {
            ConsoleKey.H => Mood.Happy,
            ConsoleKey.S => Mood.Sad,
            ConsoleKey.U => Mood.Surprise,
            _ => Mood.Neutral
        };
    }
}
