using CommunityToolkit.Mvvm.Input;
using survival_island_2.Models;
using survival_island_2.Views;
namespace survival_island_2.ViewModels;

public partial class NewGameViewModel : BaseViewModel
{
  public string SelectedProfession { get; set; }
  public string InputPlayerName { get; set; }


  public NewGameViewModel()
  {
    Title = "New Game";
  }


  [RelayCommand]
  public async Task CreatePlayerAndStartGame()
  {
    var newPlayer = CreatePlayer(SelectedProfession);
    if (newPlayer != null)
    {
      newPlayer.PlayerName = InputPlayerName;
      await Shell.Current.GoToAsync($"{nameof(MainGameView)}", true, new Dictionary<string, object>()
      {
        {
          "NewPlayer", newPlayer
        }
      });
    }
    else await Shell.Current.DisplayAlert("No Profession selected!", "Select a Profession to proceed.", "Okay");
  }

  [RelayCommand]
  public async Task GoToMainMenu()
  {
    await Shell.Current.GoToAsync("..", true);
  }

  private Player? CreatePlayer(string selectedProfession)
  {
    switch (selectedProfession)
    {
      case "Carpenter":
        return new Player(
          "Carpenter",
          1,
          0.5,
          1.5,
          1,
          1
          );
      case "Cook":
        return new Player(
          "Cook",
          0.5,
          1,
          1,
          1.5,
          1);
      case "Explorer":
        return new Player(
          "Explorer",
          1,
          1.5,
          1,
          0.5,
          1
          );
      case "Soldier":
        return new Player(
          "Soldier",
          1.5,
          1,
          0.5,
          1,
          1
          );
      case "Tourist":
        return new Player(
          "Tourist",
          1,
          1,
          1,
          1,
          1.5
          );
      default:
        return null;
    }

  }
}
