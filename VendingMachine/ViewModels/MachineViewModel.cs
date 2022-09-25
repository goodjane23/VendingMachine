using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace VendingMachine.ViewModels;

public class MachineViewModel : ICommand
{
    public class MachineViewModel :  ICommand
    {
        public string Screen { get; private set; }

        private ICommand _numberClick;
        private ICommand _okClick;
        private ICommand _cancelClick;
        public ICommand NumberClick
        {
            get { return _numberClick ?? (_numberClick = new RelayCommand<string>(ToScreen)); }
        }

        public ICommand OkClick
        {
            get { return _okClick ?? (_okClick = new RelayCommand(PressedOkClick)); } 
        }

        public ICommand CancelClick 
        { 
            get { return _cancelClick??(_cancelClick = new RelayCommand(PressedCancelClick)); } 
        }

        public MachineViewModel()
        {
           
        }
        
        private void ToScreen(string num)
        {
            Screen += num;
            if (Screen.Length > 2)
                return;
            
        }
        private void PressedOkClick()
        {
            Screen = "";
        }
        private void PressedCancelClick()
        {
            Screen = "__";
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
