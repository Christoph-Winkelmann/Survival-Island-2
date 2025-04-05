using System;
using CommunityToolkit.Mvvm.Input;
using survival_island_2.Views;

namespace survival_island_2.ViewModels;

public partial class SettingsViewModel : BaseViewModel
{
  public SettingsViewModel()
  {
    Title = "Settings";
  }

  // [RelayCommand]
  // public async Task SaveGame()
  // {

  // }

  // [RelayCommand]
  // public async Task LoadGame()
  // {

  // }

  [RelayCommand]
  public async Task GoToMainMenu()
  {
    var choice = await Shell.Current.DisplayActionSheet(
      "Unsaved progress will be lost. Really go back to Main Menu?",
      "Cancel",
      null,
      "Yes"
    );
    if (choice == "Yes") await Shell.Current.GoToAsync($"{nameof(MainMenuView)}", true);
  }

  [RelayCommand]
  public async Task ExitToDesktop()
  {
    var choice = await Shell.Current.DisplayActionSheet(
      "Unsaved progress will be lost. Really exit to Desktop?",
      "Cancel",
      null,
      "Yes"
    );
    if (choice == "Yes") Environment.Exit(0);
  }

  [RelayCommand]
  public async Task GoToMainGameView()
  {
    await Shell.Current.GoToAsync("..", true);
  }
}
