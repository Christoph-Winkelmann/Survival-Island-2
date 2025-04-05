using System;
using CommunityToolkit.Mvvm.Input;

namespace survival_island_2.ViewModels;

public partial class CraftingViewModel : BaseViewModel
{
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
