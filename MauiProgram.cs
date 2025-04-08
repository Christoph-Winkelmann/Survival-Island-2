using Microsoft.Extensions.Logging;
using survival_island_2.Services;
using survival_island_2.ViewModels;
using survival_island_2.Views;

namespace survival_island_2;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


		// Dependency-Injection Views
		builder.Services.AddSingleton<MainMenuView>();
		builder.Services.AddSingleton<CreditsView>();
		builder.Services.AddTransient<NewGameView>();
		builder.Services.AddTransient<MainGameView>();
		builder.Services.AddSingleton<SettingsView>();
		builder.Services.AddSingleton<CraftingView>();
		builder.Services.AddSingleton<StatusView>();
		builder.Services.AddSingleton<EndScreenView>();

		// Dependency-Injection ViewModels
		builder.Services.AddSingleton<MainMenuViewModel>();
		builder.Services.AddSingleton<CreditsViewModel>();
		builder.Services.AddTransient<NewGameViewModel>();
		builder.Services.AddTransient<MainGameViewModel>();
		builder.Services.AddSingleton<SettingsViewModel>();
		builder.Services.AddSingleton<CraftingViewModel>();
		builder.Services.AddSingleton<StatusViewModel>();
		builder.Services.AddSingleton<EndScreenViewModel>();

		// Dependency-Injection Services
		builder.Services.AddSingleton<GameService>();

    // Dependency-Injection DbContext


#if DEBUG
    builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
