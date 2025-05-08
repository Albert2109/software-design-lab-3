using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class Renderer
    {
        private static readonly Dictionary<Mood, RenderState> states = new()
        {
            [Mood.Neutral] = new NeutralState(),
            [Mood.Happy] = new HappyState(),
            [Mood.Sad] = new SadState(),
            [Mood.Surprise] = new SurpriseState()
        };

        public RenderState State { get; private set; }
        public Renderer(Mood initialMood = Mood.Neutral)
        {
            State = states[initialMood];
        }
        public void ChangeState(Mood mood)
        {
            if (states.ContainsKey(mood))
                State = states[mood];
        }
        public void HandleInput(ConsoleKey key)
        {
            var nextMood = State.HandleInput(key);
            ChangeState(nextMood);
        }
        public string Render(LightElementNode node) => State.Render(node);
    }
}
