using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using survival_island_2.Models;
using survival_island_2.Services;

namespace survival_island_2.ViewModels;

public partial class StatusViewModel : BaseViewModel
{
  [ObservableProperty]
  Player player;

  [ObservableProperty]
  Inventory resourcesInventory;

  [ObservableProperty]
  IslandLocation currentIslandLocation;

  [ObservableProperty]
  ObservableCollection<Craftable> availableItemsList;

  private GameService gameService;
  public StatusViewModel(GameService gameService)
  {
    Title = "Status";
    this.gameService = gameService;
    Player = gameService.MyPlayer;
    ResourcesInventory = gameService.ResourcesInventory;
    CurrentIslandLocation = gameService.CurrentIslandLocation;
    AvailableItemsList = gameService.AvailableItemsList;

  }

  [RelayCommand]
  public async Task GoToMainGameView()
  {
    await Shell.Current.GoToAsync("..", true);
  }
}
