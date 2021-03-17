using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySQL
{
    public static int playerId;
    public static string username;
    public static int level;
    public static int money;
    public static int playerExperience;
    public static int experienceNeeded;
    public static int tomatoSeeds;
    public static int potatoSeeds;
    public static int cornSeeds;
    public static int carrotSeeds;
    public static int cucumberSeeds;
    public static int eggplantSeeds;
    public static int[] whatPlant = new int[17];
    public static int[] timerPlantGrow = new int[17];
    public static bool[] startTimer = new bool[17];
    public static string[] soilPath = new string[17];
    public static bool[] isPlanted = new bool[17];
    public static int newAccount;
    public static int[] plantState = new int[17];
    public static string gameVersionInGame = "b0.02";
    public static bool localBuild = true;  //true pentru localbuild(sa folosesc eu cu localhost) ;; false pt network build (ip)
    public static bool[] isSoilLocked = new bool[17];

    public static bool loggedIn { get { return username != null; } }
    public static void LogOut()
    {
        username = null;
    }
}
