namespace survival_island_2.Services;
using survival_island_2.Models;

public class GameService
{
  public List<IslandLocation> GetIslandLocations() => new List<IslandLocation>()
  {
    new IslandLocation(
      "Beach",
      "A sunny beach with palm trees and a clear blue ocean.",
      1,
      1,
      0.5,
      0.5,
      1,
      0.2,
      ["River", "Grasslands"],
      "beach01.png"
      ),
    new IslandLocation(
      "Jungle",
      "A dense jungle with tall trees and exotic plants.",
      1,
      1,
      1,
      0.5,
      0.5,
      0.3,
      ["River", "Mountains"],
      "jungle01.png"
      ),
    new IslandLocation(
      "River",
      "A flowing river with clear water and fish.",
      0.5,
      1,
      0.5,
      1,
      0.5,
      0.1,
      ["Beach", "Jungle"],
      "river01.png"
      ),
    new IslandLocation(
      "Grasslands",
      "Flowery fields as far as the eye can see.",
      0.2,
      0.5,
      1,
      0.5,
      0.7,
      0.1,
      ["Beach", "Mountains"],
      "grasslands01.png"
      ),
    new IslandLocation(
      "Mountains",
      "A rocky mountain with steep cliffs and a breathtaking view.",
      0.5,
      0.5,
      0.5,
      1,
      0.5,
      0.4,
      ["Grasslands", "Jungle"],
      "mountains04.png"
      ),
  };

  
}
