using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Shapes;
using Syncfusion.Maui.Core;
using System.Collections.ObjectModel;
using TPERS.View.Services.Icons;

namespace TPERS.View.Pages.Components.Modal;

public partial class IconSelecterModal : Popup<IconPropertys>
{
	private readonly Color[] iconColors = 
	[
        Color.FromArgb("00FF00"),
        Color.FromArgb("9ACD32"),
        Color.FromArgb("FFFF00"),
        Color.FromArgb("FFD700"),
        Color.FromArgb("FFA500"),
        Color.FromArgb("FF4500"),
        Color.FromArgb("FF0000"),
        Color.FromArgb("C71585"),
        Color.FromArgb("800080"),
        Color.FromArgb("4B0082"),
        Color.FromArgb("0000FF"),
        Color.FromArgb("00CED1")
    ];

	public ObservableCollection<string> IconList { get; } = new ObservableCollection<string>();
	public ObservableCollection<Color> ColorsList { get; } = new ObservableCollection<Color>();

	public string selectedIconCode;
	public Color selectedColor = Color.FromArgb("FFFFFF");

    public IconSelecterModal(string iconImage ,Color color)
	{
		InitializeComponent();
		GerateIcons();

        BindingContext = this;

        icon.iconImage = iconImage;
        icon.iconColor = color;
    }

    private void GerateIcons()
	{
        foreach (var c in FASolid.AlIcons)
            IconList.Add(c);

        foreach (var d in iconColors)
            ColorsList.Add(d);
    }

	public void SelectIcon(object sender, SelectionChangedEventArgs e)
	{
		selectedIconCode = e.CurrentSelection.FirstOrDefault() as string;

        icon.iconImage = selectedIconCode;
    }

	public void SelectColor(object sender, SelectionChangedEventArgs e)
	{
		selectedColor = (Color)e.CurrentSelection.FirstOrDefault();

		icon.iconColor = selectedColor;
    }

    private void CancelButton(object sender, EventArgs e)
    {

    }
    private async void SaveButton(object sender, EventArgs e)
    {
        IconPropertys iconData = new IconPropertys(selectedIconCode, selectedColor);
		
        await CloseAsync(iconData);
    }
}