using System.Collections.ObjectModel;

namespace WpfApplication3.ViewModel
{
    public class AddCommand : BaseCommand
    {
        public ObservableCollection<string> DataLocation { get; set; }
        public string Data { get; set; }

        public override void Execute()
        {
            DataLocation.Add(Data);
        }

        public override void UnExecute()
        {
            DataLocation.Remove(Data);
        }
    }
}