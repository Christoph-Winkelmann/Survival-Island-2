using survival_island_2.ViewModels;

namespace survival_island_2.Views;

public partial class SettingsView : ContentPage
{
	public SettingsView(SettingsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}