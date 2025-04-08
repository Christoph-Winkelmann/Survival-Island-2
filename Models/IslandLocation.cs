namespace survival_island_2.Models;

public class IslandLocation
{
  public string LocationName { get; set; } = "DefaultLocation";
  public string Description { get; set; } = "Default description";
  public double LogsMod { get; set; }
  public double SticksMod { get; set; }
  public double FibersMod { get; set; }
  public double StonesMod { get; set; }
  public double FoodMod { get; set; }
  public double ThreatLevel { get; set; }

  public IslandLocation(string locationName, string description, double logsMod, double sticksMod, double fibersMod, double stonesMod, double foodMod, double threatLevel)
  {
    LocationName = locationName;
    Description = description;
    LogsMod = logsMod;
    SticksMod = sticksMod;
    FibersMod = fibersMod;
    StonesMod = stonesMod;
    FoodMod = foodMod;
    ThreatLevel = threatLevel;
  }
}
