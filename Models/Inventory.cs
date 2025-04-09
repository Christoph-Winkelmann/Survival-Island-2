namespace survival_island_2.Models;

public class Inventory
{
  public double LogsCount { get; set; } = 0;
  public double SticksCount { get; set; } = 0;
  public double FibersCount { get; set; } = 0;
  public double StonesCount { get; set; } = 0;
  public double FoodCount { get; set; } = 0;
  public List<string> CraftedItems { get; set; } = [];
}