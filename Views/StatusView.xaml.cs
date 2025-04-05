using survival_island_2.ViewModels;

namespace survival_island_2.Views;

public partial class StatusView : ContentPage
{
	public StatusView(StatusViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}