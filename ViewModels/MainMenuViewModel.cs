using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using survival_island_2.Services;
using survival_island_2.Views;

namespace survival_island_2.ViewModels;

public partial class MainMenuViewModel : BaseViewModel
{
  public MainMenuViewModel()
  {
    Title = "Main Menu";

  }

  [RelayCommand]
  public async Task GoToNewGame()
  {
    await Shell.Current.GoToAsync($"{nameof(NewGameView)}", true);
  }

  // [RelayCommand]
  // public async Task LoadGame()
  // {

  // }

  [RelayCommand]
  public async Task GoToCredits()
  {
    await Shell.Current.GoToAsync($"{nameof(CreditsView)}", true);
  }

  [RelayCommand]
  public async Task ExitToDesktop()
  {
    var choice = await Shell.Current.DisplayActionSheet(
      "Do you really want to quit?",
      "Cancel",
      null,
      "Yes");
    if (choice == "Yes") Environment.Exit(0);
  }
}
