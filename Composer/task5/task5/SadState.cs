using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class SadState : RenderState
    {
        public override string Render(LightElementNode node) =>
            $"<div style='background:linear-gradient(180deg, #a1c4fd, #c2e9fb);padding:10px;'>{node.OuterHTML}</div>";

        public override Mood HandleInput(ConsoleKey key) => key switch
        {
            ConsoleKey.H => Mood.Happy,
            ConsoleKey.U => Mood.Surprise,
            ConsoleKey.S => Mood.Sad,
            _ => Mood.Neutral
        };
    }
}
