using CommunityToolkit.Mvvm.ComponentModel;

namespace survival_island_2.ViewModels;

public partial class BaseViewModel : ObservableValidator
{
  [ObservableProperty]
  string title = "Default Title";
}
