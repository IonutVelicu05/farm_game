using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
static class SaveSoilTimer
{
    public static PickSoil muie = new PickSoil();
    public static int[] plantTime = new int[17];
    public static int[] startTimerSaved = new int[17];
    public static int[] whatPlantSaved = new int[17];
    public static string[] pamantPathSaved = new string[17];
    public static void Save(int[] plantTimer, int[] startTimer, int[] whatPlant, string[] pamantPath)
    {
        //plantTime = muie.getTimers();
        //startTimerSaved = muie.getStartTimers();
        //whatPlantSaved = muie.getWhatPlant();
        /*
        for(int i=0; i<17; i++)
        {
            startTimerSaved[i] = startTimer[i];
        }
        for(int i=0; i<17; i++)
        {
            whatPlantSaved[i] = whatPlant[i];
        }*/
        startTimerSaved = startTimer;
        plantTime = plantTimer;
        whatPlantSaved = whatPlant;
        pamantPathSaved = pamantPath;
        for(int i=1; i<17; i++)
        {
            //plantTime[i] = plantTimer[i];
            //startTimerSaved[i] = startTimer[i];
            //whatPlantSaved[i] = whatPlant[i];
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/sombapula.pula");
        bf.Serialize(file, plantTime);
        bf.Serialize(file, startTimerSaved);
        bf.Serialize(file, whatPlantSaved);
        bf.Serialize(file, pamantPathSaved);
        //bf.Serialize(file, pamanturile);
        file.Close();
    }
    public static GameObject[] getGameObjects(GameObject[] obiect)
    {
        for(int i=1; i<17; i++)
        {
            //obiect[i] = pamanturile[i];
        }
        return obiect;
    }
    public static GameObject[] pulanegro()
    {
        GameObject[] givenObject = new GameObject[17];
        for (int i = 1; i < 17; i++)
        {
            //givenObject[i] = pamanturile[i];
        }
        return givenObject;
    }
    public static int[] rasamati(int[] plantTimer)
    {
        for(int i=1; i<17; i++)
        {
            plantTimer[i] = plantTime[i];
        }
        return plantTimer;
    }
    public static string[] getPamantPath()
    {
        string[] givenPath = new string[17];
        for (int i = 1; i < 17; i++)
        {
            givenPath[i] = pamantPathSaved[i];
        }
        return givenPath;
    }
    public static int[] getPlantTime()
    {
        int[] givenTimer = new int[17];
        for(int i=1; i<17; i++)
        {
            givenTimer[i] = plantTime[i]; 
        }
        return givenTimer;
    }
    public static int[] getStartTimer()
    {
        int[] givenTimer = new int[17];
        for (int i = 1; i < 17; i++)
        {
            givenTimer[i] = startTimerSaved[i];
        }
        return givenTimer;
    }
    public static int[] getWhatPlant()
    {
        int[] givenTimer = new int[17];
        for (int i = 1; i < 17; i++)
        {
            givenTimer[i] = whatPlantSaved[i];
        }
        return givenTimer;
    }


    public static FileStream Load()
    {
        if (File.Exists(Application.dataPath + "/sombapula.pula"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/sombapula.pula", FileMode.Open);
            plantTime = (int[])bf.Deserialize(file);
            startTimerSaved = (int[])bf.Deserialize(file);
            whatPlantSaved = (int[])bf.Deserialize(file);
            pamantPathSaved = (string[])bf.Deserialize(file);
            //pamanturile = (GameObject[])bf.Deserialize(file);

            /*for (int i = 0; i < 17; i++)
            {
                plantTimer[i] = plantTime[i];
                startTimer[i] = startTimerSaved[i];
                whatPlant[i] = whatPlantSaved[i];
            }*/
            
            file.Close();
            return file;
        }
        else
        {
            return null;
        }
    }
    
}
