using survival_island_2_toolkit.Professions;

namespace survival_island_2_toolkit;

public class Player
{
  public string Name { get; set; }
  public double HungerCurrent { get; set; }
  private BaseProfession _profession;

  public Player(string name, BaseProfession profession)
  {
    Name = name;
    _profession = profession;
  }
}
