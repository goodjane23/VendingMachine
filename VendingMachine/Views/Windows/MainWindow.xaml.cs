using System.Windows;
using VendingMachine.ViewModels;

namespace VendingMachine.Views.Windows;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }
}
