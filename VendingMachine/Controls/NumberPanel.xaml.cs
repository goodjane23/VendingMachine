using System;
using System.Windows;
using System.Windows.Controls;

namespace VendingMachine.Controls;

public partial class NumberPanel : UserControl
{
    public event Action? OkButtonClick; 
    public event Action? CancelButtonClick;

    public static readonly DependencyProperty ScreenTextProperty = DependencyProperty.Register(
        nameof(ScreenText), typeof(string), typeof(NumberPanel), new PropertyMetadata("", ScreenTextPropertyChanged));

    public string ScreenText
    {
        get => (string)GetValue(ScreenTextProperty);
        set => SetValue(ScreenTextProperty, value);
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

    private void OkButton_OnClick(object sender, RoutedEventArgs e) => OkButtonClick?.Invoke();

    private void CancelButton_OnClick(object sender, RoutedEventArgs e) => CancelButtonClick?.Invoke();
}
