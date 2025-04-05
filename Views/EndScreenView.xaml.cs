using CommunityToolkit.Mvvm.Input;
using survival_island_2.ViewModels;

namespace survival_island_2.Views;

public partial class EndScreenView : ContentPage
{
	public EndScreenView(EndScreenViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}