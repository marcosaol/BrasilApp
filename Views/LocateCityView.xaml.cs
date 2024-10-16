using BrasilApp.ViewModels;
using BrasilApp.Services;

namespace BrasilApp.Views;

public partial class LocateCityView : ContentPage
{
	public LocateCityView()
	{
		InitializeComponent();
		BindingContext = new LocateCitysViewModel();
	}

    private void EntryCompleted(object sender, EventArgs e)
    {
		string CityName = entry.Text;
    }
}