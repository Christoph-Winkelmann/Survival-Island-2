using CommunityToolkit.Mvvm.ComponentModel;

namespace survival_island_2.Models;

public partial class Player : ObservableObject
{
  public string PlayerName { get; set; } = "Robinson";
  public string ProfessionName { get; set; } = String.Empty;
  public double VitalityStat { get; set; }
  public double ForagingStat { get; set; }
  public double CraftingStat { get; set; }
  public double CookingStat { get; set; }
  public double LuckStat { get; set; }
  public double HungerMax { get; set; }

  [ObservableProperty]
  public double hungerCurrent;

  public Player(string professionName, double vitalityStat, double foragingStat, double craftingStat, double cookingStat, double luckStat)
  {
    ProfessionName = professionName;
    VitalityStat = vitalityStat;
    ForagingStat = foragingStat;
    CraftingStat = craftingStat;
    CookingStat = cookingStat;
    LuckStat = luckStat;
    HungerMax = vitalityStat * 100;
    HungerCurrent = HungerMax;
  }
}
