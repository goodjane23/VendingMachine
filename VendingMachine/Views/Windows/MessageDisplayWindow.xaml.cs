using System.Windows;

namespace VendingMachine.Views.Windows;

public partial class MessageDisplayWindow : Window
{
    public MessageDisplayWindow()
    {
        InitializeComponent();
    }

    public void ShowMessage(string title, string message)
    {
        Title = title;
        messageText.Text = message;

        ShowDialog();
    }
}