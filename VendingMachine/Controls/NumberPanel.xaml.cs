using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace VendingMachine.Controls;

public partial class NumberPanel : UserControl
{
    public static readonly DependencyProperty ScreenTextProperty = DependencyProperty.Register(
        nameof(ScreenText), typeof(string), typeof(NumberPanel), new PropertyMetadata("", ScreenTextPropertyChanged));
    
    public static readonly DependencyProperty OkButtonCommand = DependencyProperty.Register(
        nameof(OkClickCommand), typeof(ICommand), typeof(NumberPanel));
    
    public static readonly DependencyProperty CancelButtonCommand = DependencyProperty.Register(
        nameof(CancelClickCommand), typeof(ICommand), typeof(NumberPanel));

    public string ScreenText
    {
        get => (string)GetValue(ScreenTextProperty);
        set => SetValue(ScreenTextProperty, value);
    }
    
    public ICommand? OkClickCommand
    {
        get => (ICommand)GetValue(OkButtonCommand);
        set => SetValue(OkButtonCommand, value);
    }
    
    public ICommand? CancelClickCommand
    {
        get => (ICommand)GetValue(CancelButtonCommand);
        set => SetValue(CancelButtonCommand, value);
    }

    public NumberPanel()
    {
        InitializeComponent();
    }

    private void NumberButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (sender is not Button button)
            return;

        ScreenText += button.Content?.ToString();
    }
    
    private static void ScreenTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not NumberPanel panel)
            return;

        panel.screenLbl.Content = e.NewValue.ToString();
    }

    private void OkButton_OnClick(object sender, RoutedEventArgs e) => OkClickCommand?.Execute(null);

    private void CancelButton_OnClick(object sender, RoutedEventArgs e) => CancelClickCommand?.Execute(null);
}
