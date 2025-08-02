using HomeWork.CommonMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Handlers.RepeatsCommandThrewException
{
    public class RepeatsCommandThrewExceptionCommand : ICommand
    {
        public ICommand _command;

        public RepeatsCommandThrewExceptionCommand(ICommand command)
        {
            _command = command;
        }

        public void Execute()
        {
            _command.Execute();
        }
    }
}
