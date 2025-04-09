using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using survival_island_2.Models;
using survival_island_2.Services;
using survival_island_2.Views;

namespace survival_island_2.ViewModels;

[QueryProperty(nameof(Player), "NewPlayer")]
//[QueryProperty(nameof(CurrentIslandLocation), "CurrentIslandLocation")]
public partial class MainGameViewModel : BaseViewModel
{
  private GameService gameService;

  [ObservableProperty]
  Player player;

  [ObservableProperty]
  IslandLocation currentIslandLocation;



  public MainGameViewModel(GameService gameService)
  {
    Title = "Main Game";
    this.gameService = gameService;
    var IslandLocations = gameService.GetIslandLocations();
    CurrentIslandLocation = IslandLocations[0];
  }

  [RelayCommand]
  public async Task LookAroundPrompt()
  {
    await Shell.Current.DisplayAlert(
      "Look around",
      $"{CurrentIslandLocation.Description}",
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
    var choice = await Shell.Current.DisplayActionSheet(
      "Where do you want to go?",
      "Cancel",
      null,
      $"{CurrentIslandLocation.NeighbouringLocations[0]}",
      $"{CurrentIslandLocation.NeighbouringLocations[1]}"
    );
    var destination = gameService.GetIslandLocations().FirstOrDefault(l => l.LocationName == choice);

    if (destination != null)
    {
      CurrentIslandLocation = destination;
      await Shell.Current.DisplayAlert(
        "Travel",
        $"You have traveled to the {CurrentIslandLocation.LocationName}",
        "Continue"
      );
    }
  }

  [RelayCommand]
  public async Task GoToCraftingView()
  {
    await Shell.Current.GoToAsync($"{nameof(CraftingView)}", true, new Dictionary<string, object>()
    {
      {
        "CurrentIslandLocation", CurrentIslandLocation
      }
    });
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
