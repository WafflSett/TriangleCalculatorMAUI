using CommunityToolkit.Maui.Views;

namespace TriangleCalculatorMAUI.Popups;

public partial class PopupPage : Popup
{
    public string Header { get; set; }
    public string Description { get; set; }
    public PopupPage(string header, string description)
	{
		InitializeComponent();
        Header = header;
        Description = description;
        this.BindingContext = this;
	}

    private async void Close_BTN_Clicked(object sender, EventArgs e)
    {
        await this.CloseAsync();
    }
}