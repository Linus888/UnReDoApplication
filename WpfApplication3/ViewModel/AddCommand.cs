using System.Collections.ObjectModel;

namespace WpfApplication3.ViewModel
{
    public class AddCommand : ICommand
    {
        public ObservableCollection<string> DataLocation { get; set; }
        public string Data { get; set; }
        public bool IsSelected { get; set; }

        public void Execute()
        {
            DataLocation.Add(Data);
        }

        public void UnExecute()
        {
            DataLocation.Remove(Data);
        }
    }
}