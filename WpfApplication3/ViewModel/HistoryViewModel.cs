using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication3.Helpers;

namespace WpfApplication3.ViewModel
{
    class HistoryViewModel
    {
        private HistoryDialog _dialogWindow;

        public HistoryViewModel()
        {
            CancelCommand = new RelayCommand(Cancel);
        }

        public Stack<ICommand> HistoryStack { get; set; }

        public RelayCommand CancelCommand { get; set; }

        public void ShowDialogWindow()
        {
            // This is a property of the DialogViewModelBase class - thus, each DialogViewModel holds a reference to its own DialogWindow:
            this._dialogWindow = new HistoryDialog();
            // Tell the DialogWindow to display this ViewModel:
            this._dialogWindow.DataContext = this;
            // Launch the Window, using a method of the Window baseclass, that only returns when the window is closed:
            bool? result = this._dialogWindow.ShowDialog();
        }

        protected void CloseDialogWithResult(bool dialogWindowResult)
        {
            // Setting this property automatically closes the dialog window:
            this._dialogWindow.DialogResult = dialogWindowResult;
        }

        private void Cancel(object parameter)
        {
            CloseDialogWithResult(false);
        }
    }
}
