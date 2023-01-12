﻿using System;
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

    //void WindowStateChanged(object sender, EventArgs e)
    //{
    //    var w = ((Window)sender);
    //    var handle = w.GetWindowHandle();
    //    var containerBorder = (Border)w.Template.FindName("PART_Container", w);

    //    if (w.WindowState == WindowState.Maximized)
    //    {
    //        // Make sure window doesn't overlap with the taskbar.
    //        var screen = Screen.FromHandle(handle);
    //        if (screen.Primary)
    //        {
    //            containerBorder.Padding = new Thickness(
    //                SystemParameters.WorkArea.Left + 7,
    //                SystemParameters.WorkArea.Top + 7,
    //                (SystemParameters.PrimaryScreenWidth - SystemParameters.WorkArea.Right) + 7,
    //                (SystemParameters.PrimaryScreenHeight - SystemParameters.WorkArea.Bottom) + 5);
    //        }
    //    }
    //    else
    //    {
    //        containerBorder.Padding = new Thickness(7, 7, 7, 5);
    //    }
    //}

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
