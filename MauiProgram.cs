using Microsoft.Extensions.Logging;
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

		// Dependency-Injection ViewModels
		builder.Services.AddSingleton<MainMenuViewModel>();
		builder.Services.AddSingleton<CreditsViewModel>();
		builder.Services.AddTransient<NewGameViewModel>();

		// Dependency-Injection Services

		// Dependency-Injection DbContext


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
