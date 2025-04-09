﻿using CommunityToolkit.Mvvm.ComponentModel;

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

  [ObservableProperty]
  bool hasBeenCrafted = false;

  public Craftable(int id, string craftableName, double logsCost, double sticksCost, double fibersCost, double stonesCost, double foodCost, bool hasBeenCrafted)
  {
    Id = id;
    CraftableName = craftableName;
    LogsCost = logsCost;
    SticksCost = sticksCost;
    FibersCost = fibersCost;
    StonesCost = stonesCost;
    FoodCost = foodCost;
    HasBeenCrafted = hasBeenCrafted;
  }
}
