using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using survival_island_2.Models;
using survival_island_2.Services;
using survival_island_2.Views;

namespace survival_island_2.ViewModels;

public partial class CraftingViewModel : BaseViewModel
{

  [ObservableProperty]
  Player player;

  [ObservableProperty]
  IslandLocation currentIslandLocation;

  [ObservableProperty]
  Inventory resourcesInventory;

  [ObservableProperty]
  ObservableCollection<Craftable> craftableList;

  [ObservableProperty]
  Craftable selectedCraftable;

  [ObservableProperty]
  bool selectedItemIsCraftable;



  private GameService gameService;


  public CraftingViewModel(GameService gameService)
  {
    Title = "Crafting";
    this.gameService = gameService;
    ResourcesInventory = gameService.ResourcesInventory;
    Player = gameService.MyPlayer;
    CurrentIslandLocation = gameService.CurrentIslandLocation;
    CraftableList = gameService.CraftableList;
    SelectedCraftable = CraftableList[0];
    SelectedItemIsCraftable = ItemIsCraftable(SelectedCraftable);
  }

  [RelayCommand]
  public async Task GoToMainGameView()
  {
    await Shell.Current.GoToAsync("..?Refresh=true", true);
  }

  [RelayCommand]
  public async Task SelectCraftable(Craftable craftableParam)
  {
    SelectedCraftable = craftableParam;
    SelectedItemIsCraftable = ItemIsCraftable(SelectedCraftable);
  }

  [RelayCommand]
  public void CraftSelectedCraftable()
  {
    // Set the Craftables HasBeenCrafted flag to true
    SelectedCraftable.HasBeenCrafted = true;

    // Subtract the resource-cost from the inventory and refresh UI
    gameService.SpendResources(SelectedCraftable);
    ResourcesInventory = gameService.ResourcesInventory;

    // add the crafted item to the available items and remove it from the craftable list
    gameService.AvailableItemsList.Add(SelectedCraftable);
    CraftableList.Remove(SelectedCraftable);

    // if there are still items in the list refresh the UI
    if (CraftableList.Count < 1)
    {
      Craftable newCraftable = new Craftable(99, String.Empty, 0, 0, 0, 0, 0, "There is nothing left to craft", false);
      CraftableList.Add(newCraftable);
    }
    SelectedCraftable = CraftableList[0];
    SelectedItemIsCraftable = ItemIsCraftable(SelectedCraftable);
    gameService.DecreaseHunger(10);
    gameService.AdvanceDaytime(1);
    if (gameService.CheckGameOver())
    {
      Shell.Current.GoToAsync(nameof(EndScreenView), true);
    }
  }

  public bool ItemIsCraftable(Craftable craftable)
  {
    if (craftable.Id == 99) return false;
    if (craftable.LogsCost > ResourcesInventory.LogsCount) return false;
    if (craftable.SticksCost > ResourcesInventory.SticksCount) return false;
    if (craftable.FibersCost > ResourcesInventory.FibersCount) return false;
    if (craftable.StonesCost > ResourcesInventory.StonesCount) return false;
    if (craftable.FoodCost > ResourcesInventory.FoodCount) return false;
    else return true;
  }
}
