using CommunityToolkit.Mvvm.Input;
using survival_island_2.Views;

namespace survival_island_2.ViewModels;

public partial class CreditsViewModel : BaseViewModel
{
  public CreditsViewModel()
  {
    Title = "Credits";
  }

  [RelayCommand]
  public async Task GoToMainMenu()
  {
    await Shell.Current.GoToAsync("..", true);
  }

  [RelayCommand]
  public async Task GoToHyperlink(string url)
  {
    await Launcher.OpenAsync(url);
  }
}
