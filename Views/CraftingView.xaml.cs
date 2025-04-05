using survival_island_2.ViewModels;

namespace survival_island_2.Views;

public partial class CraftingView : ContentPage
{
	public CraftingView(CraftingViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}