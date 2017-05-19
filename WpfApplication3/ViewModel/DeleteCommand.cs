using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WpfApplication3.ViewModel
{
    class DeleteCommand : BaseCommand
    {
        public ObservableCollection<string> DataLocation { get; set; }
        public string Data { get; set; }
        public int ListPosition { get; set; }
        public override void Execute()
        {
            ListPosition = DataLocation.IndexOf(Data);
            DataLocation.Remove(Data);
        }

        public override void UnExecute()
        {
            DataLocation.Insert(ListPosition, Data);

        }
    }
}
