using survival_island_2.ViewModels;

namespace survival_island_2.Views;

public partial class CreditsView : ContentPage
{
	public CreditsView(CreditsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}