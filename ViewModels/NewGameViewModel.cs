using System;
using CommunityToolkit.Mvvm.Input;
using survival_island_2.Views;

namespace survival_island_2.ViewModels;

public partial class NewGameViewModel : BaseViewModel
{
  public NewGameViewModel()
  {
    Title = "New Game";
  }


  [RelayCommand]
  public async Task GoToMainGame()
  {
    await Shell.Current.GoToAsync($"{nameof(MainGameView)}", true);
  }

  [RelayCommand]
  public async Task GoToMainMenu()
  {
    await Shell.Current.GoToAsync("..", true);
  }
}
