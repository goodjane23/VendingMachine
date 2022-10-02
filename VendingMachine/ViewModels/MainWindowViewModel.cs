using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace VendingMachine.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    private string displayText = string.Empty;
    public string DisplayText
    {
        get => displayText;
        set => SetProperty(ref displayText, value);
    }

    public ICommand OkCommand { get; }
    public ICommand CancelCommand { get; }
    
    public MainWindowViewModel()
    {
        OkCommand = new RelayCommand(() => MessageBox.Show(DisplayText));
        CancelCommand = new RelayCommand(() => DisplayText = "");
    }
}
