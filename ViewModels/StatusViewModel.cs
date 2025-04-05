using System;
using CommunityToolkit.Mvvm.Input;

namespace survival_island_2.ViewModels;

public partial class StatusViewModel : BaseViewModel
{
  public StatusViewModel()
  {
    Title = "Status";
  }

  [RelayCommand]
  public async Task GoToMainGameView()
  {
    await Shell.Current.GoToAsync("..", true);
  }
}
