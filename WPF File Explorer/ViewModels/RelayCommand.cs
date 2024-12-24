using System.Windows.Input;

namespace WPF_File_Explorer.ViewModels
{
    internal class RelayCommand : ICommand
    {
        private Action _execute;

        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _execute();
        }
    }
}
