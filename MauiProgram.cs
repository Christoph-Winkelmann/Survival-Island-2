﻿using Microsoft.Extensions.Logging;
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
		builder.Services.AddSingleton<MainGameView>();
		builder.Services.AddSingleton<SettingsView>();
		builder.Services.AddTransient<CraftingView>();
		builder.Services.AddTransient<StatusView>();
		builder.Services.AddTransient<EndScreenView>();

		// Dependency-Injection ViewModels
		builder.Services.AddSingleton<MainMenuViewModel>();
		builder.Services.AddSingleton<CreditsViewModel>();
		builder.Services.AddTransient<NewGameViewModel>();
		builder.Services.AddSingleton<MainGameViewModel>();
		builder.Services.AddSingleton<SettingsViewModel>();
		builder.Services.AddTransient<CraftingViewModel>();
		builder.Services.AddTransient<StatusViewModel>();
		builder.Services.AddTransient<EndScreenViewModel>();

		// Dependency-Injection Services
		builder.Services.AddSingleton<GameService>();

    // Dependency-Injection DbContext


#if DEBUG
    builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
