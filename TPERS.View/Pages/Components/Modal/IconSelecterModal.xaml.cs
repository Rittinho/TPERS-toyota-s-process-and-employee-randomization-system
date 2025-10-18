  using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Shapes;
using Syncfusion.Maui.Core;
using System.Collections.ObjectModel;
using System.Windows.Input;
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

	public ObservableCollection<string> IconList { get; } = [];
	public ObservableCollection<Color> ColorsList { get; } = [];

    public ICommand SaveIconChangeCommand => new Command(SaveButton);
    public ICommand CancelChangeCommand => new Command(CancelButton);

    public string selectedIconCode; 

	public Color selectedColor;

    public IconSelecterModal(string iconImage ,Color color)
	{
		InitializeComponent();
		GerateIcons();

        BindingContext = this;

        selectedIconCode = iconImage;
        selectedColor = color;

        icon.iconImage = selectedIconCode;
        icon.iconColor = selectedColor;
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
        if(e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            selectedIconCode = e.CurrentSelection[0] as string;

        icon.iconImage = selectedIconCode!;
    }

	public void SelectColor(object sender, SelectionChangedEventArgs e)
	{
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            if (e.CurrentSelection[0] is Color color)
            {
                selectedColor = color;
                icon.iconColor = selectedColor;
            }
        }
    }

    private async void CancelButton() => await CloseAsync();

    private async void SaveButton() => await CloseAsync(new IconPropertys(selectedIconCode, selectedColor));
}