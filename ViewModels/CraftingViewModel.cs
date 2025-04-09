using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using survival_island_2.Models;
using survival_island_2.Services;

namespace survival_island_2.ViewModels;

public partial class CraftingViewModel : BaseViewModel
{

  [ObservableProperty]
  Player player;

  [ObservableProperty]
  IslandLocation currentIslandLocation;

  [ObservableProperty]
  Inventory resourcesInventory;

  private GameService gameService;

  public CraftingViewModel(GameService gameService)
  {
    Title = "Crafting";
    this.gameService = gameService;
    ResourcesInventory = gameService.ResourcesInventory;
    Player = gameService.MyPlayer;
    CurrentIslandLocation = gameService.CurrentIslandLocation;
  }

  [RelayCommand]
  public async Task GoToMainGameView()
  {
    await Shell.Current.GoToAsync("..", true);
  }
}
