using CommunityToolkit.Mvvm.Input;
using survival_island_2.Models;
using survival_island_2.Services;
using survival_island_2.Views;
namespace survival_island_2.ViewModels;

public partial class NewGameViewModel : BaseViewModel
{
  public string SelectedProfession { get; set; } = "Carpenter";
  public string InputPlayerName { get; set; }
  public GameService MyGameService { get; set; }

  public NewGameViewModel(GameService gameService)
  {
    Title = "New Game";
    MyGameService = gameService;
  }


  [RelayCommand]
  public async Task CreatePlayerAndStartGame()
  {
    if (InputPlayerName == null) InputPlayerName = "Robinson";
    var creationSuccessfull = MyGameService.CreatePlayer(InputPlayerName, SelectedProfession);
    if (creationSuccessfull) await Shell.Current.GoToAsync($"{nameof(MainGameView)}", true);
    else await Shell.Current.DisplayAlert(
      "No Profession selected!",
      "Select a Profession to proceed.",
      "Okay");
  }

  [RelayCommand]
  public async Task GoToMainMenu()
  {
    await Shell.Current.GoToAsync("..", true);
  }
}
