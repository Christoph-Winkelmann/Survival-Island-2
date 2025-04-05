using System;
using CommunityToolkit.Mvvm.Input;
using survival_island_2.Views;

namespace survival_island_2.ViewModels;

public partial class EndScreenViewModel : BaseViewModel
{
  public EndScreenViewModel()
  {
    Title = "End Screen";
  }

  [RelayCommand]
  public async Task GoToMainMenuView()
  {
    await Shell.Current.GoToAsync($"{nameof(MainMenuView)}", true);
  }
}
