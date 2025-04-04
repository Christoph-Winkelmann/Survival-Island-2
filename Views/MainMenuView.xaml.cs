using survival_island_2.ViewModels;

namespace survival_island_2.Views;

public partial class MainMenuView : ContentPage
{
	public MainMenuView(MainMenuViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}