using System;
using System.Windows;
using System.Windows.Controls;

namespace VendingMachine.Controls;

public partial class Showcase : UserControl
{
    public static readonly DependencyProperty ItemHeightProperty = DependencyProperty
        .Register(nameof(ItemHeight), typeof(double), typeof(Showcase), new PropertyMetadata(0.0, ItemHeightPropertyChanged));

    public static readonly DependencyProperty ItemWidthProperty = DependencyProperty
        .Register(nameof(ItemWidth), typeof(double), typeof(Showcase), new PropertyMetadata(0.0, ItemWidthPropertyChanged));

    public double ItemHeight
    {
        get => (double)GetValue(ItemHeightProperty);
        set => SetValue(ItemHeightProperty, value);
    }

    public double ItemWidth
    {
        get => (double)GetValue(ItemWidthProperty);
        set => SetValue(ItemWidthProperty, value);
    }

    public Showcase()
    {
        InitializeComponent();
    }

    private static void ItemHeightPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not Showcase showcase)
            return;

        showcase.ItemHeight = Convert.ToDouble(e.NewValue);
    }

    private static void ItemWidthPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not Showcase showcase)
            return;

        showcase.ItemWidth = Convert.ToDouble(e.NewValue);
    }
}
