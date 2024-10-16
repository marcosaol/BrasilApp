using BrasilApp.ViewModels;

namespace BrasilApp.Views;

public partial class BanksView : ContentPage
{
	public BanksView()
	{
		InitializeComponent();
		BindingContext = new BanksViewModel();
	}

    private void GetBanks(object sender, EventArgs e)
    {

    }
}