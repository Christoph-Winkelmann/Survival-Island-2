using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using survival_island_2.Models;
using survival_island_2.Services;
using survival_island_2.Views;

namespace survival_island_2.ViewModels;

[QueryProperty(nameof(Player), "NewPlayer")]
[QueryProperty(nameof(IslandLocation), "CurrentIslandLocation")]
public partial class MainGameViewModel : BaseViewModel
{
  private GameService gameService;

  [ObservableProperty]
  Player player;

  [ObservableProperty]
  IslandLocation currentIslandLocation;

  public List<IslandLocation> IslandLocations { get; set; }



  public MainGameViewModel(GameService gameService)
  {
    Title = "Main Game";
    this.gameService = gameService;
    IslandLocations = gameService.GetIslandLocations();
  }

  [RelayCommand]
  public async Task LookAroundPrompt()
  {
    await Shell.Current.DisplayAlert(
      "Look around",
      "This is a placeholder description of the location.",
      "Continue");
  }

  [RelayCommand]
  public async Task HarvestPrompt()
  {
    await Shell.Current.DisplayAlert(
      "Harvest yield",
      "This is a placeholder summary:\nWood: 10\nStone:3",
      "Continue"
    );
  }

  [RelayCommand]
  public async Task TravelPrompt()
  {
    await Shell.Current.DisplayActionSheet(
      "Where do you want to go?",
      "Cancel",
      null,
      "Example location 1", "Example location 2"
    );
  }

  [RelayCommand]
  public async Task GoToCraftingView()
  {
    await Shell.Current.GoToAsync($"{nameof(CraftingView)}", true);
  }

  [RelayCommand]
  public async Task GoToStatusView()
  {
    await Shell.Current.GoToAsync($"{nameof(StatusView)}", true);
  }

  [RelayCommand]
  public async Task GoToSettingsView()
  {
    await Shell.Current.GoToAsync($"{nameof(SettingsView)}", true);
  }

}
