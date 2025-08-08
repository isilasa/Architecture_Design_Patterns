using HomeWork.CommonMethod;

namespace HomeWork.Commands
{
    public class MacroComamnd: ICommand
    {
        private readonly IList<ICommand> _chainCommands;

        public MacroComamnd(IList<ICommand> chainCommands)
        {
            _chainCommands = chainCommands;
        }

        public void Execute()
        {
            foreach (var command in _chainCommands)
            {
                command.Execute();
            }
        }
    }
}
