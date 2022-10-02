using System.Windows;
using VendingMachine.ViewModels;

namespace VendingMachine.Views.Windows;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new MainWindowViewModel();
    }
}
