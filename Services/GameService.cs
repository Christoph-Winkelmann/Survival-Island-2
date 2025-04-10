﻿namespace survival_island_2.Services;

using CommunityToolkit.Mvvm.ComponentModel;
using survival_island_2.Models;
using System.Collections.ObjectModel;

public partial class GameService : ObservableObject
{
  [ObservableProperty]
  Inventory resourcesInventory = new Inventory();
  public Player MyPlayer { get; set; }
  public List<IslandLocation> IslandLocationsList { get; set; } = new List<IslandLocation>()
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
      "beach01_banner.png"
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
      "jungle01_banner.png"
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
      "river01_banner.png"
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
      "grasslands01_banner.png"
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
      "mountains04_banner.png"
      ),
  };
  public IslandLocation CurrentIslandLocation { get; set; }
  public List<IslandLocation> GetIslandLocations() => IslandLocationsList;
  public List<Player> GetProfessionList() => new List<Player>()
  {
    new Player(
          "Carpenter",
          1,
          0.5,
          1.5,
          1,
          1),
    new Player(
          "Cook",
          0.5,
          1,
          1,
          1.5,
          1),
    new Player(
          "Explorer",
          1,
          1.5,
          1,
          0.5,
          1),
    new Player(
          "Soldier",
          1.5,
          1,
          0.5,
          1,
          1),
    new Player(
          "Tourist",
          1,
          1,
          1,
          1,
          1.5)
  };
  public ObservableCollection<Craftable> CraftableList { get; set; } = new ObservableCollection<Craftable>()
  {
    new Craftable(
      0,
      "Axe",
      0,
      10,
      10,
      10,
      0,
      "Axe for chopping trees and gathering logs.\nIncreases the amount of logs gathered when harvesting resources.",
      false),
    new Craftable(
      1,
      "Basket",
      0,
      20,
      50,
      0,
      20,
      "Basket for gathering small resources.\nIncreases the amount of sticks, fibers and food gathered when harvesting resources.",
      false),
    new Craftable(
      2,
      "Campfire",
      10,
      20,
      20,
      10,
      10,
      "Campfire for cooking food.\nReduces the amount of food used when cooking.",
      false),
    new Craftable(
      3,
      "Raft Body",
      100,
      100,
      100,
      0,
      0,
      "One of three parts needed to build a raft.\nPractically a bunch of logs tied together.",
      false),
    new Craftable(
      4,
      "Raft Sail",
      50,
      50,
      200,
      0,
      0,
      "One of three parts needed to build a raft.\nA sail to catch the wind and move faster.",
      false),
    new Craftable(
      5,
      "Raft Rations",
      0,
      0,
      100,
      0,
      100,
      "One of three parts needed to build a raft.\nA bunch of food to keep you alive.",
      false),
  };
  public ObservableCollection<Craftable> AvailableItemsList { get; set; } = [];
  public string TimeOfDay { get; set; }
  public int CurrentDay { get; set; } = 1;

  public GameService()
  {
    CurrentIslandLocation = IslandLocationsList[0];
  }

  // Player Stuff
  public bool CreatePlayer(string playerName, string chosenProfession)
  {
    var newPlayer = GetProfessionList().FirstOrDefault(p => p.ProfessionName == chosenProfession);
    if (newPlayer != null)
    {
      newPlayer.PlayerName = playerName;
      MyPlayer = newPlayer;
      return true;
    }
    else return false;
  }



  // Inventory Stuff


  public string HarvestResources(IslandLocation location, Player myPlayer)
  {
    // implement cases where axe and/or basket are available

    // calculate yields based on location and player stats
    var logsYield = Math.Floor(1000 * location.LogsMod * myPlayer.ForagingStat);
    var sticksYield = Math.Floor(1000 * location.SticksMod * myPlayer.ForagingStat);
    var fibersYield = Math.Floor(1000 * location.FibersMod * myPlayer.ForagingStat);
    var stonesYield = Math.Floor(1000 * location.StonesMod * myPlayer.ForagingStat);
    var foodYield = Math.Floor(1000 * location.FoodMod * myPlayer.ForagingStat);

    var newInventory = new Inventory()
    {
      LogsCount = ResourcesInventory.LogsCount,
      SticksCount = ResourcesInventory.SticksCount,
      FibersCount = ResourcesInventory.FibersCount,
      StonesCount = ResourcesInventory.StonesCount,
      FoodCount = ResourcesInventory.FoodCount,
    };
    // add yields to inventory
    newInventory.LogsCount += logsYield;
    newInventory.SticksCount += sticksYield;
    newInventory.FibersCount += fibersYield;
    newInventory.StonesCount += stonesYield;
    newInventory.FoodCount += foodYield;

    ResourcesInventory = newInventory;

    // return a string with the yields for UI
    return
      $"Logs: +{logsYield}\n" +
      $"Sticks: +{sticksYield}\n" +
      $"Fibers: +{fibersYield}\n" +
      $"Stones: +{stonesYield}\n" +
      $"Food: +{foodYield}";
  }

  public void SpendResources(Craftable craftable)
  {
    var newInventory = new Inventory()
    {
      LogsCount = ResourcesInventory.LogsCount,
      SticksCount = ResourcesInventory.SticksCount,
      FibersCount = ResourcesInventory.FibersCount,
      StonesCount = ResourcesInventory.StonesCount,
      FoodCount = ResourcesInventory.FoodCount,
    };
    // add yields to inventory
    newInventory.LogsCount -= craftable.LogsCost;
    newInventory.SticksCount -= craftable.SticksCost;
    newInventory.FibersCount -= craftable.FibersCost;
    newInventory.StonesCount -= craftable.StonesCost;
    newInventory.FoodCount -= craftable.FoodCost;

    ResourcesInventory = newInventory;
  }


}
