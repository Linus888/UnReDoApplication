using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3.ViewModel
{
    public abstract class BaseCommand : ICommand
    {
        public bool IsSelected { get; set; }
        public abstract void Execute();
        public abstract void UnExecute();
    }
}
