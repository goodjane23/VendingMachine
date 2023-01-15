using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace VendingMachine.Resources.Styles.MainWindow;

internal static class LocalExtensions
{
    public static void ForWindowFromTemplate(this object templateFrameworkElement, Action<Window> action)
    {
        Window window = ((FrameworkElement)templateFrameworkElement).TemplatedParent as Window;

        if (window != null)
            action?.Invoke(window);
    }

    public static IntPtr GetWindowHandle(this Window window)
    {
        var helper = new WindowInteropHelper(window);
        return helper.Handle;
    }
}

public partial class WindowStyle
{
    private void IconMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount > 1)
            sender.ForWindowFromTemplate(w => SystemCommands.CloseWindow(w));
    }

    private void IconMouseUp(object sender, MouseButtonEventArgs e)
    {
        var element = sender as FrameworkElement;
        var point = element.PointToScreen(new Point(element.ActualWidth / 2, element.ActualHeight));

        sender.ForWindowFromTemplate(w => SystemCommands.ShowSystemMenu(w, point));
    }

    private void WindowLoaded(object sender, RoutedEventArgs e)
    {
        //((Window)sender).StateChanged += WindowStateChanged;
    }

    private void CloseButtonClick(object sender, RoutedEventArgs e)
    {
        sender.ForWindowFromTemplate(w => SystemCommands.CloseWindow(w));
    }

    private void MinButtonClick(object sender, RoutedEventArgs e)
    {
        sender.ForWindowFromTemplate(w => SystemCommands.MinimizeWindow(w));
    }

    private void MaxButtonClick(object sender, RoutedEventArgs e)
    {
        sender.ForWindowFromTemplate(w =>
        {
            if (w.WindowState == WindowState.Maximized)
                SystemCommands.RestoreWindow(w);
            else 
                SystemCommands.MaximizeWindow(w);
        });
    }
}
