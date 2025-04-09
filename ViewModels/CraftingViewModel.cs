using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using survival_island_2.Models;

namespace survival_island_2.ViewModels;

[QueryProperty(nameof(Player), "NewPlayer")]
[QueryProperty(nameof(CurrentIslandLocation), "CurrentIslandLocation")]
public partial class CraftingViewModel : BaseViewModel
{
  [ObservableProperty]
  Player player;
  [ObservableProperty]
  IslandLocation currentIslandLocation;

  public CraftingViewModel()
  {
    Title = "Crafting";
  }

  [RelayCommand]
  public async Task GoToMainGameView()
  {
    await Shell.Current.GoToAsync("..", true);
  }
}
