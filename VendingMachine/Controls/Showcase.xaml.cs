using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace VendingMachine.Controls;

public partial class Showcase : UserControl
{
    public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty
        .Register(nameof(ItemTemplate), typeof(DataTemplate), typeof(Showcase),
                    new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnItemTemplateChanged)));

    public static readonly DependencyProperty ItemsProperty = DependencyProperty
        .Register(nameof(Items), typeof(IEnumerable), typeof(Showcase), new PropertyMetadata(null, ItemsPropertyChanged));

    public static readonly DependencyProperty ItemHeightProperty = DependencyProperty
        .Register(nameof(ItemHeight), typeof(double), typeof(Showcase), new PropertyMetadata(0.0, ItemHeightPropertyChanged));

    public static readonly DependencyProperty ItemWidthProperty = DependencyProperty
        .Register(nameof(ItemWidth), typeof(double), typeof(Showcase), new PropertyMetadata(0.0, ItemWidthPropertyChanged));

    public DataTemplate ItemTemplate
    { 
        get => (DataTemplate)GetValue(ItemTemplateProperty); 
        set => SetValue(ItemTemplateProperty, value); 
    }

    public IEnumerable Items 
    {
        get => (IEnumerable)GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

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

    private static void OnItemTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not Showcase showcase)
            return;

        showcase.itemsControl.ItemTemplate = e.NewValue as DataTemplate;
    }

    private static void ItemsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not Showcase showcase)
            return;

        showcase.itemsControl.ItemsSource = e.NewValue as IEnumerable;
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
