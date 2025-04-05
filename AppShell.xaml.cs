using survival_island_2.Views;

namespace survival_island_2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(MainMenuView), typeof(MainMenuView));
		Routing.RegisterRoute(nameof(CreditsView), typeof(CreditsView));
		Routing.RegisterRoute(nameof(NewGameView), typeof(NewGameView));
		Routing.RegisterRoute(nameof(MainGameView), typeof(MainGameView));
		Routing.RegisterRoute(nameof(SettingsView), typeof(SettingsView));
		Routing.RegisterRoute(nameof(CraftingView), typeof(CraftingView));
		Routing.RegisterRoute(nameof(StatusView), typeof(StatusView));
		Routing.RegisterRoute(nameof(EndScreenView), typeof(EndScreenView));
	}
}
