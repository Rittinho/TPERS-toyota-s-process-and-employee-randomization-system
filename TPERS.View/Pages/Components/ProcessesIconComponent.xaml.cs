using TPERS.View.Services.Icons;

namespace TPERS.View.Pages.Components;

public partial class ProcessesIconComponent : ContentView
{
    public static readonly BindableProperty iconSizeProperty =
    BindableProperty.Create(nameof(iconSize), typeof(int), typeof(ProcessesIconComponent), default(int), propertyChanged: OnIconSizePropertyChanged);

    public static readonly BindableProperty iconColorProperty =
    BindableProperty.Create(nameof(iconColor), typeof(Color), typeof(ProcessesIconComponent), default(Color));

    public static readonly BindableProperty iconImageProperty =
    BindableProperty.Create(nameof(iconImage), typeof(string), typeof(ProcessesIconComponent), default(string));

    public int iconSize
    {
        get => (int)GetValue(iconSizeProperty);
        set => SetValue(iconSizeProperty, value);
    }
    public Color iconColor
    {
        get => (Color)GetValue(iconColorProperty);
        set => SetValue(iconColorProperty, value);
    }
    public string iconImage
    {
        get => (string)GetValue(iconImageProperty);
        set => SetValue(iconImageProperty, value);
    }
    public ProcessesIconComponent()
	{
		InitializeComponent();
        externalBorder.Padding = iconSize * 0.10;
        icon.FontSize = iconSize * 0.50;
    }
    public static void OnIconSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (ProcessesIconComponent)bindable;
        control.externalBorder.Padding = (int)newValue * 0.07;
        control.icon.FontSize = (int)newValue * 0.50;
    }
}