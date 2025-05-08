using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class MacroCommand : ICommand
    {
        private readonly List<ICommand> cmds = new();
        public void Add(ICommand cmd) => cmds.Add(cmd);
        public void Execute() => cmds.ForEach(c => c.Execute());
        public void Undo() => cmds.AsEnumerable().Reverse().ToList().ForEach(c => c.Undo());
    }
}
