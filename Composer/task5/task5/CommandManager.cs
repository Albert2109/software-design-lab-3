using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    public class CommandManager
    {
        private readonly Stack<ICommand> undoStack = new();
        private readonly Stack<ICommand> redoStack = new();

        public void Execute(ICommand cmd)
        {
            cmd.Execute();
            undoStack.Push(cmd);
            redoStack.Clear();
        }

        public void Undo()
        {
            if (!undoStack.Any()) return;
            var cmd = undoStack.Pop();
            cmd.Undo();
            redoStack.Push(cmd);
        }

        public void Redo()
        {
            if (!redoStack.Any()) return;
            var cmd = redoStack.Pop();
            cmd.Execute();
            undoStack.Push(cmd);
        }
    }
}
