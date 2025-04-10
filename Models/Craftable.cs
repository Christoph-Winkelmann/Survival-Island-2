using CommunityToolkit.Mvvm.ComponentModel;

namespace survival_island_2.Models;

public partial class Craftable : ObservableObject
{
  public int Id { get; set; }
  public string CraftableName { get; set; } = String.Empty;
  public double LogsCost { get; set; }
  public double SticksCost { get; set; }
  public double FibersCost { get; set; }
  public double StonesCost { get; set; }
  public double FoodCost { get; set; }
  public string Description { get; set; } = String.Empty;
  public double ToolMod { get; set; } = 0;

  [ObservableProperty]
  bool hasBeenCrafted = false;

  public Craftable(int id, string craftableName, double logsCost, double sticksCost, double fibersCost, double stonesCost, double foodCost, string description, bool hasBeenCrafted, double toolMod = 0)
  {
    Id = id;
    CraftableName = craftableName;
    LogsCost = logsCost;
    SticksCost = sticksCost;
    FibersCost = fibersCost;
    StonesCost = stonesCost;
    FoodCost = foodCost;
    Description = description;
    HasBeenCrafted = hasBeenCrafted;
  }
}
