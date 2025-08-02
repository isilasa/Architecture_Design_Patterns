using HomeWork.CommonMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Commands
{
    public class SimpleCommand : ICommand
    {
        public void Execute()
        {
            throw new Exception("Simple command");
        }
    }
}
