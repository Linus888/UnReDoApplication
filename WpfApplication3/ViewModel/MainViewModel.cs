using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using WpfApplication3.Helpers;

namespace WpfApplication3.ViewModel
{
    interface ICommand
    {
        void Execute();
        void UnExecute();
    }


    partial class MainViewModel
    {
        public MainViewModel()
        {
            //Definition RelayCommand
            SaveCommand = new RelayCommand(Save);
            AddItemCommand = new RelayCommand(AddItem);
            RemoveItemCommand = new RelayCommand(RemoveItem);
            DuplicateItemCommand = new RelayCommand(DuplicateItem);
            UnDoItemCommand = new RelayCommand(UnDoItem);
            ReDoItemCommand = new RelayCommand(ReDoItem);
            PopItemToStack = new RelayCommand(PopItem);
            //initializing properties
            ListItems = new ObservableCollection<string>();
            UnDoStack = new Stack<ICommand>();
            ReDoStack = new Stack<ICommand>();
            TestStack = new Stack<ListItem>();
        }

        private void Save(object obj)
        {
            HistoryViewModel dialog = new HistoryViewModel();
            dialog.HistoryStack = UnDoStack;
            dialog.ShowDialogWindow();
        }

        public RelayCommand SaveCommand { get; set; }

        public Stack<ListItem> TestStack { get; set; }

        public Stack<ICommand> ReDoStack { get; set; }
        public Stack<ICommand> UnDoStack { get; set; }
        public RelayCommand ReDoItemCommand { get; set; }
        public RelayCommand PopItemToStack { get; set; }
        public RelayCommand UnDoItemCommand { get; set; }
        public RelayCommand RemoveItemCommand { get; set; }
        public RelayCommand DuplicateItemCommand { get; set; }
        public RelayCommand AddItemCommand { get; set; }

        public string TextBoxText { get; set; }

        //Property
        public ObservableCollection<string> ListItems { get; set; }

        //Für den Inhalt der Textbox
        public string InputString { get; set; }

        public string SelectedListitem { get; set; }


        private void PopItem(object obj)
        {
            throw new NotImplementedException();
        }


        private void ReDoItem(object obj)
        {
            //ListItems.Add(ReDoStack.Peek());
            //ReDoStack.Pop();
            if (ReDoStack.Any())
            {
                var currentCommand = ReDoStack.Pop();
                currentCommand.Execute();
                UnDoStack.Push(currentCommand);
            }
        }


        private void UnDoItem(object obj)
        {
            //ReDoStack.Push(UnDoStack.Peek());
            //ListItems.Remove(UnDoStack.Pop());
            if (UnDoStack.Any())
            {
                var currentCommand = UnDoStack.Pop();
                currentCommand.UnExecute();
                ReDoStack.Push(currentCommand);
            }
        }

        private void DuplicateItem(object obj)
        {
            
        }


        private void RemoveItem(object obj)
        {

                DeleteCommand currentCommand = new DeleteCommand();
                currentCommand.Data = SelectedListitem;
                currentCommand.DataLocation = ListItems;
                currentCommand.Execute();
                UnDoStack.Push(currentCommand);
                ReDoStack.Clear();
        }

        private void AddItem(object parameter)
        {
            

            #region build Command

            AddCommand currentCommand = new AddCommand();
            currentCommand.Data = InputString;
            currentCommand.DataLocation = ListItems;
            currentCommand.Execute();

            #endregion

            UnDoStack.Push(currentCommand);
            ReDoStack.Clear();
        }
    }
}
