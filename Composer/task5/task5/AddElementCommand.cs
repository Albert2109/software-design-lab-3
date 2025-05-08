using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class AddElementCommand : ICommand
    {
        private readonly LightElementNode parent;
        private readonly LightElementNode element;
        public AddElementCommand(LightElementNode p, string tag)
        {
            parent = p;
            element =  new LightElementNode(tag);
        }
        public void Execute() => parent.AddChild(element);
        public void Undo() => parent.Children.Remove(element);
    }
}
