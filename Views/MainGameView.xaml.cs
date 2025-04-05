using survival_island_2.ViewModels;

namespace survival_island_2.Views;

public partial class MainGameView : ContentPage
{
	public MainGameView(MainGameViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}