using survival_island_2.ViewModels;

namespace survival_island_2.Views;

public partial class NewGameView : ContentPage
{
	public NewGameView(NewGameViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}