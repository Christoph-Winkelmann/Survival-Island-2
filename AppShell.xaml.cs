using survival_island_2.Views;

namespace survival_island_2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		// Routing.RegisterRoute(nameof(MainMenuView), typeof(MainMenuView));
		Routing.RegisterRoute(nameof(CreditsView), typeof(CreditsView));
	}
}
