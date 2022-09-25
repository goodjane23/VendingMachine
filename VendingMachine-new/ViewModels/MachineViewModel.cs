using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace VendingMachine.ViewModels
{
    public class MachineViewModel : ICommand
    {
        public string Screen
        {
            get;
            private set;
        }

        private ICommand _nuberClik;
        private ICommand _okClick;
        private ICommand _cancelClick;
        ICommand NuberClik
        {
            get { return _nuberClik ?? (_nuberClik = new RelayCommand<int>(ToScreen)); }
        }

        ICommand OkClick
        {
            get { return _okClick ?? (_okClick = new RelayCommand(PressedOkClick)); }
        }

        ICommand CancelClick
        {
            get { return _cancelClick ?? (_cancelClick = new RelayCommand(PressedCancelClick)); }
        }

        public MachineViewModel()
        {

        }

        private void ToScreen(int num)
        {
            Screen += num;
            if (Screen.Length > 2)
                return;

        }
        private void PressedOkClick()
        {

        }
        private void PressedCancelClick()
        {

        }






        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
