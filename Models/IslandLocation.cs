using CommunityToolkit.Mvvm.ComponentModel;

namespace survival_island_2.Models;

public partial class IslandLocation : ObservableObject
{
  public string LocationName { get; set; } = "DefaultLocation";
  public string Description { get; set; } = "Default description";
  public double LogsMod { get; set; }
  public double SticksMod { get; set; }
  public double FibersMod { get; set; }
  public double StonesMod { get; set; }
  public double FoodMod { get; set; }
  public double ThreatLevel { get; set; }
  public List<string> NeighbouringLocations { get; set; }
  public string LocationArtPath { get; set; } = String.Empty;

  public IslandLocation(string locationName, string description, double logsMod, double sticksMod, double fibersMod, double stonesMod, double foodMod, double threatLevel, List<string> neighbouringLocations, string locationArtPath)
  {
    LocationName = locationName;
    Description = description;
    LogsMod = logsMod;
    SticksMod = sticksMod;
    FibersMod = fibersMod;
    StonesMod = stonesMod;
    FoodMod = foodMod;
    ThreatLevel = threatLevel;
    NeighbouringLocations = neighbouringLocations;
    LocationArtPath = locationArtPath;
  }
}
