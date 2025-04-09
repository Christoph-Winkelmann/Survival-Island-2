using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using survival_island_2.Models;
using survival_island_2.Services;
using survival_island_2.Views;

namespace survival_island_2.ViewModels;

public partial class MainGameViewModel : BaseViewModel
{
  private GameService gameService;


  [ObservableProperty]
  IslandLocation currentIslandLocation;

  [ObservableProperty]
  Inventory resourcesInventory;

  [ObservableProperty]
  Player player;


  public MainGameViewModel(GameService gameService)
  {
    Title = "Main Game";
    this.gameService = gameService;
    CurrentIslandLocation = gameService.CurrentIslandLocation;
    ResourcesInventory = gameService.ResourcesInventory;
    Player = gameService.MyPlayer;
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
    string harvestYield = gameService.HarvestResources(CurrentIslandLocation, Player) ?? "Default string";
    await Shell.Current.DisplayAlert(
      "Harvest yield",
      message: harvestYield,
      "Continue"
    );
    ResourcesInventory = gameService.ResourcesInventory;
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
      await Shell.Current.DisplayAlert(
        "Travel",
        $"You have traveled to the {destination.LocationName}",
        "Continue"
      );
      CurrentIslandLocation = destination;
    }
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
