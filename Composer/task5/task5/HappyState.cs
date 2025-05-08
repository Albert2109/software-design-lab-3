using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class HappyState : RenderState
    {
        public override string Render(LightElementNode node) =>
            $"<div style='background:linear-gradient(45deg, #ff9a9e, #fad0c4);padding:10px;'>{node.OuterHTML}</div>";

        public override Mood HandleInput(ConsoleKey key) => key switch
        {
            ConsoleKey.S => Mood.Sad,
            ConsoleKey.U => Mood.Surprise,
            ConsoleKey.H => Mood.Happy,
            _ => Mood.Neutral
        };
    }
}
