using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class SurpriseState : RenderState
    {
        public override string Render(LightElementNode node) =>
            $"<div style='position:relative;padding:10px;'>{node.OuterHTML}<canvas class='sparkle' data-target='content'></canvas></div>";

        public override Mood HandleInput(ConsoleKey key) => key switch
        {
            ConsoleKey.H => Mood.Happy,
            ConsoleKey.S => Mood.Sad,
            ConsoleKey.U => Mood.Surprise,
            _ => Mood.Neutral
        };
    }
}
