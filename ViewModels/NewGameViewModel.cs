using System;
using CommunityToolkit.Mvvm.Input;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace survival_island_2.ViewModels;

public partial class NewGameViewModel : BaseViewModel
{
  public NewGameViewModel()
  {
    Title = "New Game";
  }

  public List<string> professions = new List<string> { "Carpenter", "Cook" };

  [RelayCommand]
  public async Task GoToMainMenu()
  {
    await Shell.Current.GoToAsync("..", true);
  }
}
