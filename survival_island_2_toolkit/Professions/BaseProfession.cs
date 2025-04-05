using System;

namespace survival_island_2_toolkit.Professions;

public class BaseProfession
{
  public string ProfessionName { get; set; }
  public double Vitality { get; set; }
  public double Perception { get; set; }
  public double Wisdom { get; set; }
  public double Luck { get; set; }
  public double HungerMax { get; set; }
}
