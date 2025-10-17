using Microsoft.Maui;
using Microsoft.Maui.Controls.Shapes;

namespace TPERS.View.Pages.Components.Elements;

public partial class VerticalIconButton : ContentView
{
    public static readonly BindableProperty ButtonBackgroundColorProperty =
   BindableProperty.Create(nameof(ButtonBackgroundColor), typeof(Color), typeof(IconButtonComponent), default(Color));

    public static readonly BindableProperty ButtonTextColorProperty =
    BindableProperty.Create(nameof(ButtonTextColor), typeof(Color), typeof(IconButtonComponent), default(Color));

    public static readonly BindableProperty TextButtonProperty =
    BindableProperty.Create(nameof(TextButton), typeof(string), typeof(IconButtonComponent), default(string));

    public static readonly BindableProperty IconButtonProperty =
    BindableProperty.Create(nameof(IconButton), typeof(string), typeof(IconButtonComponent), default(string));

    public static readonly BindableProperty ButtonIconPositionProperty =
       BindableProperty.Create(
       nameof(ButtonVerticalIconPosition),
       typeof(VerticalAlignment),
       typeof(IconButtonComponent),
       defaultValue: VerticalAlignment.Up,
       propertyChanged: OnIconPositionChanged);

    public static readonly BindableProperty ButtonTextAlignmentProperty =
        BindableProperty.Create(
        nameof(ButtonHorizontalTextAlignment),
        typeof(HorizontalAlignment),
        typeof(IconButtonComponent),
        defaultValue: HorizontalAlignment.Center,
        propertyChanged: OnTextAlignmentChanged);

    public static readonly BindableProperty ButtonHeightRequestProperty =
   BindableProperty.Create(nameof(ButtonHeightRequest), typeof(int), typeof(IconButtonComponent), default(int));

    public static readonly BindableProperty ButtonWidthRequestProperty =
    BindableProperty.Create(nameof(ButtonWidthRequest), typeof(int), typeof(IconButtonComponent), default(int));

    public static readonly BindableProperty ButtonCornerRadiusProperty =
    BindableProperty.Create(nameof(ButtonCornerRadius), typeof(int), typeof(IconButtonComponent), default(int));

    public Color ButtonBackgroundColor
    {
        get => (Color)GetValue(ButtonBackgroundColorProperty);
        set => SetValue(ButtonBackgroundColorProperty, value);
    }

    public Color ButtonTextColor
    {
        get => (Color)GetValue(ButtonTextColorProperty);
        set => SetValue(ButtonTextColorProperty, value);
    }

    public VerticalAlignment ButtonVerticalIconPosition
    {
        get => (VerticalAlignment)GetValue(ButtonIconPositionProperty);
        set => SetValue(ButtonIconPositionProperty, value);
    }

    public HorizontalAlignment ButtonHorizontalTextAlignment
    {
        get => (HorizontalAlignment)GetValue(ButtonTextAlignmentProperty);
        set => SetValue(ButtonTextAlignmentProperty, value);
    }

    public string TextButton
    {
        get => (string)GetValue(TextButtonProperty);
        set => SetValue(TextButtonProperty, value);
    }

    public string IconButton
    {
        get => (string)GetValue(IconButtonProperty);
        set => SetValue(IconButtonProperty, value);
    }

    public int ButtonHeightRequest
    {
        get => (int)GetValue(ButtonHeightRequestProperty);
        set => SetValue(ButtonHeightRequestProperty, value);
    }

    public int ButtonWidthRequest
    {
        get => (int)GetValue(ButtonWidthRequestProperty);
        set => SetValue(ButtonWidthRequestProperty, value);
    }

    public int ButtonCornerRadius
    {
        get => (int)GetValue(ButtonCornerRadiusProperty);
        set => SetValue(ButtonCornerRadiusProperty, value);
    }

    public VerticalIconButton()
	{
		InitializeComponent();
        BindingContext = this;
        SetTextPosition();
        SetIconPosition();
    }

    private static void OnIconPositionChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (IconButtonComponent)bindable;
        control.SetIconPosition();
    }

    private static void OnTextAlignmentChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (IconButtonComponent)bindable;
        control.SetTextPosition();
    }

    public void IconUpButton()
    {
        ButtonGrid.ColumnDefinitions.Clear();
        ButtonGrid.RowDefinitions.Clear();

        ButtonGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        ButtonGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });

        Grid.SetRow(IconLabel, 0);
        Grid.SetRow(TextLabel, 1);
    }

    public void IconDownButton()
    {
        ButtonGrid.ColumnDefinitions.Clear();
        ButtonGrid.RowDefinitions.Clear();

        ButtonGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
        ButtonGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        Grid.SetRow(TextLabel, 0);
        Grid.SetRow(IconLabel, 1);
    }

    public void SetIconPosition()
    {
        switch (ButtonVerticalIconPosition)
        {

            case VerticalAlignment.Up:
                IconUpButton();
                break;

            case VerticalAlignment.Down:
                IconDownButton();
                break;

        }

        VisualButtonOptions(ButtonCornerRadius);
        SetTextPosition();
    }

    public void VisualButtonOptions(int value)
    {
        ButtonBorder.StrokeShape = new RoundRectangle { CornerRadius = value };
        ButtonBorder.Padding = 10;

        IconLabel.FontSize = ButtonHeightRequest * 0.6;
        TextLabel.FontSize = ButtonHeightRequest * 0.3;
    }

    public void SetTextPosition()
    {
        switch (ButtonHorizontalTextAlignment)
        {
            case HorizontalAlignment.Center:
                TextLabel.HorizontalOptions = LayoutOptions.Center;
                break;

            case HorizontalAlignment.Left:
                TextLabel.HorizontalOptions = LayoutOptions.Start;
                break;

            case HorizontalAlignment.Right:
                TextLabel.HorizontalOptions = LayoutOptions.End;
                break;

        }
    }
}