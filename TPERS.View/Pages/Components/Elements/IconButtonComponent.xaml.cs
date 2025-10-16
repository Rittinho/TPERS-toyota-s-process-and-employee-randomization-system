namespace TPERS.View.Pages.Components.Elements;

public enum IconPosition
{
    Left,
    Right
}
public enum TextAlignment
{
    Left,
    Right,
    Center
}

public partial class IconButtonComponent : ContentView
{
    public static readonly BindableProperty ButtonBackgroundColorProperty =
    BindableProperty.Create(nameof(ButtonBackgroundColor), typeof(Color), typeof(IconButtonComponent), default(Color));

    public static readonly BindableProperty ButtonTextColorProperty =
    BindableProperty.Create(nameof(ButtonTextColor), typeof(Color), typeof(IconButtonComponent), default(Color));

    public static readonly BindableProperty TextButtonProperty =
    BindableProperty.Create(nameof(TextButton), typeof(string), typeof(IconButtonComponent), default(string));

    public static readonly BindableProperty IconButtonProperty =
    BindableProperty.Create(nameof(IconButton), typeof(string), typeof(IconButtonComponent), default(string));

    public static readonly BindableProperty ButtonHorizontalIconPositionProperty =
    BindableProperty.Create(nameof(ButtonHorizontalIconPosition), typeof(IconPosition), typeof(IconButtonComponent), defaultValue: IconPosition.Left);

    public static readonly BindableProperty ButtonHorizontalTextAlignmentProperty =
    BindableProperty.Create(nameof(ButtonHorizontalTextAlignment), typeof(TextAlignment), typeof(IconButtonComponent), defaultValue: TextAlignment.Center);

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

    public IconPosition ButtonHorizontalIconPosition
    {
        get => (IconPosition)GetValue(ButtonHorizontalIconPositionProperty);
        set => SetValue(ButtonHorizontalIconPositionProperty, value);
    }

    public TextAlignment ButtonHorizontalTextAlignment
    {
        get => (TextAlignment)GetValue(ButtonHorizontalTextAlignmentProperty);
        set => SetValue(ButtonHorizontalTextAlignmentProperty, value);
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

    public int FontSize;

    public IconButtonComponent()
	{
		InitializeComponent();
        BindingContext = this;
    }
}