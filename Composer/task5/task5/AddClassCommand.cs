using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class AddClassCommand : ICommand
    {
        private readonly LightElementNode target;
        private readonly string cls;
        public AddClassCommand(LightElementNode t, string cls) { target = t; this.cls = cls; }
        public void Execute() => target.AddClass(cls);
        public void Undo() => target.CssClasses.Remove(cls);
    }
}
