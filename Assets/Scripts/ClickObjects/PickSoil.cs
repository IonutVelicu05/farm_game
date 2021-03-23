using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using TMPro;

[Serializable]
public class PickSoil : MonoBehaviour
{
    
    public GameObject seedMenu;
    public GameObject seedInventory;
    private bool pickPlant = false;
    private bool[] alreadyPlanted = new bool[17]; //daca in slot e deja planta
    private int[] plantState = new int[17]; // 1=begin // 2=aproape gata(efecte) // 3=e gata(imagine floare) // 4=moarta
    private bool[] startTimer = new bool[17]; // 0 = oprit // 1=pornit
    private int[] timerPlantGrow = new int[17]; // timer pentru fiecare slot
    //Ce planta este pe slotu de pamant ->
    // 1=rosie // 2=grau // 3=carrot // 4=potato // 5=cucumber // 6=eggplant
    private int[] whatPlant = new int[17]; //ce planta e in fiecare slot
    // End la what plant ;
    private int pickedSoil;
    [SerializeField]
    private Sprite tomato;
    [SerializeField]
    private Sprite plantBegin;
    [SerializeField]
    private Sprite corn;
    [SerializeField]
    private Sprite carrot;
    [SerializeField]
    private Sprite potato;
    [SerializeField]
    private Sprite cucumber;
    [SerializeField]
    private Sprite eggplant;
    private GameObject[] pamantAles = new GameObject[17];
    private string[] pamantPath = new string[17];
    private int[] plantWater = new int[17];
    GameObject eroare;

    private Image[] imageOfPlant = new Image[17];
    private int whatToPick = 1;
    [SerializeField]
    private bool[] isSoilUnlocked = new bool[17];
    [SerializeField]
    private Sprite lockedSoil;
    [SerializeField]
    private GameObject unlockSoil;
    [SerializeField]
    private GameObject unlockSoilError;
    [SerializeField]
    private TextMeshProUGUI unlockSoilPrice;
    private GameObject[] needWaterIcons = new GameObject[17];
    [SerializeField]
    private Sprite needWaterImage;
    private bool[] soilNeedWater = new bool[17];
    private bool waterPlants = false;
    private int plantWaterTime = 30; // show water icon
    private int plantDeadTime = 40; // when the plant dies
    private bool[] isPlantDead = new bool[17]; // is it dead or not 
    [SerializeField]
    private Sprite deadPlantImage;
    private bool removeDeadPlant = false;

    public void OnApplicationQuit()
    {
        CallSaveSoils();
    }
    private void UnlockSoilScript()
    {
        StartCoroutine(UnlockSoilScriptEnumerator());
    }
    IEnumerator UnlockSoilScriptEnumerator()
    {
        WWWForm form = new WWWForm();
        form.AddField("soilId", pickedSoil);
        form.AddField("playerName", MySQL.username);
        if (MySQL.localBuild)
        {
            WWW www = new WWW("http://localhost/connection/unlocksoil.php", form);
            yield return www;
            if(www.text == "0")
            {
                Debug.Log("a MERS BA UAOWAU");
            }
            else
            {
                Debug.Log(www.text);   
            }
        }
        else if(MySQL.localBuild == false)
        {
            WWW www = new WWW("http://localhost/connection/unlocksoil_online.php", form);
            yield return www;
            if (www.text == "0")
            {
                Debug.Log("a MERS BA UAOWAU");
            }
            else
            {
                Debug.Log(www.text);
            }
        }
    }
    public void UnlockSoil()
    {
        for (int i = 5; i < 17; i++)
        {
            if (pickedSoil == i)
            {
                pamantAles[i] = GameObject.Find("CanvasMeniu/pamantPlante/" + i);
                if (MySQL.money >= i * 10)
                {

                    pamantAles[i].GetComponent<Image>().sprite = null;
                    pamantAles[i].GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.23f);
                    MySQL.money -= i * 10;
                    UnlockSoilScript();
                    isSoilUnlocked[i] = true;
                }
                else
                {
                    unlockSoilError.SetActive(true);
                }
            }
        }
    }
    private void checkUnlockedSoils()
    {
        for(int i = 5; i < 17; i++)
        {
            pamantAles[i] = GameObject.Find("CanvasMeniu/pamantPlante/" + i);
            if(isSoilUnlocked[i] == true)
            {
                pamantAles[i].GetComponent<Image>().sprite = null;
                pamantAles[i].GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.23f);
            }
            else if(isSoilUnlocked[i] == false)
            {
                pamantAles[i].GetComponent<Image>().sprite = lockedSoil;
                pamantAles[i].GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.65f);
            }
        }
    }
    public void CallLoadSoils()
    {
       
        StartCoroutine(LoadPlayerSoil());
    }
    IEnumerator LoadPlayerSoil() //load funcion
    {
        for (int j = 0; j<8; j++)
        {
            WWWForm form = new WWWForm();
            form.AddField("name", MySQL.username);
            form.AddField("whatToPick", whatToPick);
            if (MySQL.localBuild)
            {
                WWW www = new WWW("http://localhost/connection/loadsoils.php", form);
                yield return www;
                switch (whatToPick)
                {
                    case 1:
                        for (int i = 1; i < 17; i++)
                        {
                            if (www.text.Split('\t')[i] == "True")
                            {
                                MySQL.isPlanted[i] = true;
                            }
                            else if (www.text.Split('\t')[i] == "False")
                            {
                                MySQL.isPlanted[i] = false;
                            }
                        }
                        whatToPick = 2;
                        break;
                    case 2:
                        for (int i = 1; i < 17; i++)
                        {
                            int.TryParse(www.text.Split('\t')[i], out MySQL.whatPlant[i]);
                        }
                        whatToPick = 3;
                        break;
                    case 3:
                        for (int i = 1; i < 17; i++)
                        {
                            bool.TryParse(www.text.Split('\t')[i], out MySQL.startTimer[i]);
                        }
                        whatToPick = 4;
                        break;
                    case 4:
                        for (int i = 1; i < 17; i++)
                        {
                            int.TryParse(www.text.Split('\t')[i], out MySQL.timerPlantGrow[i]);
                        }
                        whatToPick = 5;
                        break;
                    case 5:
                        for (int i = 1; i < 17; i++)
                        {
                            int.TryParse(www.text.Split('\t')[i], out MySQL.plantState[i]);
                        }
                        whatToPick = 6;
                        break;
                    case 6:
                        for(int i = 1; i < 17; i++)
                        {
                            bool.TryParse(www.text.Split('\t')[i], out isSoilUnlocked[i]);
                            checkUnlockedSoils();
                        }
                        whatToPick = 7;
                        break;
                    case 7:
                        for(int i = 1; i < 17; i++)
                        {
                            int.TryParse(www.text.Split('\t')[i], out plantWater[i]);
                        }
                        whatToPick = 8;
                        break;
                    case 8:
                        for(int i = 1; i < 17; i++)
                        {
                            bool.TryParse(www.text.Split('\t')[i], out isPlantDead[i]);
                            whatToPick = 1;
                        }
                        break;
                }
            }
            else if(MySQL.localBuild == false)
            {
                WWW www = new WWW("http://guta-farm.000webhostapp.com/connection/loadsoils_online.php", form);
                yield return www;
                switch (whatToPick)
                {
                    case 1:
                        for (int i = 1; i < 17; i++)
                        {
                            if (www.text.Split('\t')[i] == "True")
                            {
                                MySQL.isPlanted[i] = true;
                            }
                            else if (www.text.Split('\t')[i] == "False")
                            {
                                MySQL.isPlanted[i] = false;
                            }
                        }
                        whatToPick = 2;
                        break;
                    case 2:
                        for (int i = 1; i < 17; i++)
                        {
                            int.TryParse(www.text.Split('\t')[i], out MySQL.whatPlant[i]);
                        }
                        whatToPick = 3;
                        break;
                    case 3:
                        for (int i = 1; i < 17; i++)
                        {
                            bool.TryParse(www.text.Split('\t')[i], out MySQL.startTimer[i]);
                        }
                        whatToPick = 4;
                        break;
                    case 4:
                        for (int i = 1; i < 17; i++)
                        {
                            int.TryParse(www.text.Split('\t')[i], out MySQL.timerPlantGrow[i]);
                        }
                        whatToPick = 5;
                        break;
                    case 5:
                        for (int i = 1; i < 17; i++)
                        {
                            int.TryParse(www.text.Split('\t')[i], out MySQL.plantState[i]);
                        }
                        whatToPick = 6;
                        break;
                    case 6:
                        for (int i = 1; i < 17; i++)
                        {
                            bool.TryParse(www.text.Split('\t')[i], out isSoilUnlocked[i]);
                            checkUnlockedSoils();
                        }
                        whatToPick = 7;
                        break;
                    case 7:
                        for (int i = 1; i < 17; i++)
                        {
                            int.TryParse(www.text.Split('\t')[i], out plantWater[i]);
                        }
                        whatToPick = 1;
                        break;
                }
            }
        }
    }
    public void CallSaveSoils()
    {
        StartCoroutine(SavePlayerSoils());
    }
    IEnumerator SavePlayerSoils()
    {
        MySQL.soilPath[0] = "";
        for(int i=1; i<17; i++)
        {
            WWWForm form = new WWWForm();
            form.AddField("newAccount", MySQL.newAccount);
            form.AddField("isPlanted", MySQL.isPlanted[i].ToString());
            form.AddField("timerPlantGrow", MySQL.timerPlantGrow[i]);
            form.AddField("startTimer", MySQL.startTimer[i].ToString());
            form.AddField("whatPlant", MySQL.whatPlant[i]);
            form.AddField("indexArray", i);
            form.AddField("name", MySQL.username);
            form.AddField("plantState", MySQL.plantState[i].ToString());
            form.AddField("isSoilUnlocked", isSoilUnlocked[i].ToString());
            form.AddField("plantWater", plantWater[i].ToString());
            form.AddField("isPlantDead", isPlantDead[i].ToString());
            if (MySQL.localBuild)
            {
                WWW www = new WWW("http://localhost/connection/savesoil.php", form);
                yield return www;
                if(www.text == "0")
                {
                    Debug.Log("bvbvbvbv save suces");
                }
                else
                {
                    Debug.Log(www.text);
                }
            }
            else if(MySQL.localBuild == false)
            {
                WWW www = new WWW("http://guta-farm.000webhostapp.com/connection/savesoil_online.php", form);
                yield return www;
            }
            
        } 
        MySQL.LogOut();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void AutoSaveSoil()
    {
        StartCoroutine(AutoSaveSoilEnumerator());
    }
    IEnumerator AutoSaveSoilEnumerator()
    {
        MySQL.soilPath[0] = "";
        for (int i = 0; i < 17; i++)
        {
            WWWForm form = new WWWForm();
            form.AddField("newAccount", MySQL.newAccount);
            form.AddField("isPlanted", MySQL.isPlanted[i].ToString());
            form.AddField("timerPlantGrow", MySQL.timerPlantGrow[i]);
            form.AddField("startTimer", MySQL.startTimer[i].ToString());
            form.AddField("soilPath", MySQL.soilPath[i].ToString());
            form.AddField("whatPlant", MySQL.whatPlant[i]);
            form.AddField("indexArray", i);
            form.AddField("name", MySQL.username);
            form.AddField("plantState", MySQL.plantState[i].ToString());
            form.AddField("plantWater", plantWater[i]);
            if (MySQL.localBuild)
            {
                WWW www = new WWW("http://localhost/connection/savesoil.php", form);
                yield return www;
            }
            else if (MySQL.localBuild == false)
            {
                WWW www = new WWW("http://guta-farm.000webhostapp.com/connection/savesoil_online.php", form);
                yield return www;
            }

        }
    }
    private void LoadGame()
    {
        CallLoadSoils();
        timerPlantGrow = MySQL.timerPlantGrow;
        whatPlant = MySQL.whatPlant;
        startTimer = MySQL.startTimer;



        for (int i = 0; i < 17; i++) //seteaza pamanturile sa fie obiectele cu path-ul respectiv.
        {
            pamantAles[i] = GameObject.Find("CanvasMeniu/pamantPlante/" + i);
        }
        for (int i = 0; i < 17; i++)
        {
            //daca stringu de la pamantPath[i] e null nu face nimic
            //daca are path-ul la un obiect in el seteaza imaginea obiectului
            if (!string.IsNullOrEmpty(pamantPath[i]))
            {
                imageOfPlant[i] = pamantAles[i].GetComponent<Image>();
            }
        }
        timerPlantIncrease();
    }
    public void PickPlantButton()
    {
        pickPlant = !pickPlant;
    }
    public void Harvest()
    {
        if (pickPlant)
        {
            for (int i = 0; i < 17; i++)
            {
                if (i == pickedSoil)
                {
                    if (MySQL.plantState[i] == 3 && isPlantDead[i] != true)
                    {
                        pamantAles[i] = GameObject.Find("CanvasMeniu/pamantPlante/" + i);
                        switch (MySQL.whatPlant[i])
                        {
                            case 1:
                                MySQL.tomatoSeeds++;
                                pamantAles[i].GetComponent<Image>().sprite = null;
                                pamantAles[i].GetComponent<Image>().color = new Color(0f, 0f, 0f, .23f);
                                MySQL.isPlanted[i] = false;
                                MySQL.startTimer[i] = false;
                                MySQL.timerPlantGrow[i] = 0;
                                MySQL.plantState[i] = 0;
                                MySQL.playerExperience += 5;
                                MySQL.whatPlant[i] = 0;
                                if (MySQL.playerExperience >= MySQL.experienceNeeded)
                                {
                                    MySQL.playerExperience = MySQL.playerExperience - MySQL.experienceNeeded;
                                    MySQL.level++;
                                    MySQL.experienceNeeded = 10 * MySQL.level * MySQL.level;
                                }
                                break;
                            case 2:
                                MySQL.cornSeeds++;
                                pamantAles[i].GetComponent<Image>().sprite = null;
                                pamantAles[i].GetComponent<Image>().color = new Color(0f, 0f, 0f, .23f);
                                MySQL.isPlanted[i] = false;
                                MySQL.startTimer[i] = false;
                                MySQL.timerPlantGrow[i] = 0;
                                MySQL.plantState[i] = 0;
                                MySQL.playerExperience += 10;
                                MySQL.whatPlant[i] = 0;
                                if (MySQL.playerExperience >= MySQL.experienceNeeded)
                                {
                                    MySQL.playerExperience = MySQL.playerExperience - MySQL.experienceNeeded;
                                    MySQL.level++;
                                    MySQL.experienceNeeded = 10 * MySQL.level * MySQL.level;
                                }
                                break;
                            case 3:
                                MySQL.carrotSeeds++;
                                pamantAles[i].GetComponent<Image>().sprite = null;
                                pamantAles[i].GetComponent<Image>().color = new Color(0f, 0f, 0f, .23f);
                                MySQL.isPlanted[i] = false;
                                MySQL.startTimer[i] = false;
                                MySQL.timerPlantGrow[i] = 0;
                                MySQL.plantState[i] = 0;
                                MySQL.playerExperience += 15;
                                MySQL.whatPlant[i] = 0;
                                if (MySQL.playerExperience >= MySQL.experienceNeeded)
                                {
                                    MySQL.playerExperience = MySQL.playerExperience - MySQL.experienceNeeded;
                                    MySQL.level++;
                                    MySQL.experienceNeeded = 10 * MySQL.level * MySQL.level;
                                }
                                break;
                            case 4:
                                MySQL.potatoSeeds++;
                                pamantAles[i].GetComponent<Image>().sprite = null;
                                pamantAles[i].GetComponent<Image>().color = new Color(0f, 0f, 0f, .23f);
                                MySQL.isPlanted[i] = false;
                                MySQL.startTimer[i] = false;
                                MySQL.timerPlantGrow[i] = 0;
                                MySQL.plantState[i] = 0;
                                MySQL.playerExperience += 1;
                                MySQL.whatPlant[i] = 0;
                                if (MySQL.playerExperience >= MySQL.experienceNeeded)
                                {
                                    MySQL.playerExperience = MySQL.playerExperience - MySQL.experienceNeeded;
                                    MySQL.level++;
                                    MySQL.experienceNeeded = 10 * MySQL.level * MySQL.level;
                                }
                                break;
                            case 5:
                                MySQL.cucumberSeeds++;
                                pamantAles[i].GetComponent<Image>().sprite = null;
                                pamantAles[i].GetComponent<Image>().color = new Color(0f, 0f, 0f, .23f);
                                MySQL.isPlanted[i] = false;
                                MySQL.startTimer[i] = false;
                                MySQL.timerPlantGrow[i] = 0;
                                MySQL.plantState[i] = 0;
                                MySQL.playerExperience += 20;
                                MySQL.whatPlant[i] = 0;
                                if (MySQL.playerExperience >= MySQL.experienceNeeded)
                                {
                                    MySQL.playerExperience = MySQL.playerExperience - MySQL.experienceNeeded;
                                    MySQL.level++;
                                    MySQL.experienceNeeded = 10 * MySQL.level * MySQL.level;
                                }
                                break;
                            case 6:
                                MySQL.eggplantSeeds++;
                                pamantAles[i].GetComponent<Image>().sprite = null;
                                pamantAles[i].GetComponent<Image>().color = new Color(0f, 0f, 0f, .23f);
                                MySQL.isPlanted[i] = false;
                                MySQL.startTimer[i] = false;
                                MySQL.timerPlantGrow[i] = 0;
                                MySQL.plantState[i] = 0;
                                MySQL.playerExperience += 25;
                                MySQL.whatPlant[i] = 0;
                                if (MySQL.playerExperience >= MySQL.experienceNeeded)
                                {
                                    MySQL.playerExperience = MySQL.playerExperience - MySQL.experienceNeeded;
                                    MySQL.level++;
                                    MySQL.experienceNeeded = 10 * MySQL.level * MySQL.level;
                                }
                                break;
                        }
                    }
                }
            }
        }
        else if (removeDeadPlant == true)
        {
            for(int i = 0; i < 17; i++)
            {
                if(i == pickedSoil)
                {
                    isPlantDead[i] = false;
                    pamantAles[i].GetComponent<Image>().sprite = null;
                    pamantAles[i].GetComponent<Image>().color = new Color(0f, 0f, 0f, .23f);
                    needWaterIcons[i].SetActive(false);
                    MySQL.isPlanted[i] = false;
                    MySQL.startTimer[i] = false;
                    MySQL.timerPlantGrow[i] = 0;
                    MySQL.plantState[i] = 0;
                    MySQL.whatPlant[i] = 0;
                    plantWater[i] = 0;
                }
            }
        }
        else if (isSoilUnlocked[pickedSoil] == false)
        {
            for (int i = 0; i < 17; i++)
            {
                if (pickedSoil == i)
                {
                    unlockSoilPrice.text = "Price: " + i * 10;
                }
            }
            unlockSoil.SetActive(true);
        }
        else if (waterPlants == true)
        {
            for(int i = 0; i < 17; i++)
            {
                if (pickedSoil == i && soilNeedWater[i] == true)
                {
                    if((plantWater[i] - 30) < 0)
                    {
                        plantWater[i] = 0;
                    }
                    else
                    {
                    plantWater[i] -= 30;
                    }
                }
                else if (pickedSoil == i && soilNeedWater[i] == false)
                {
                    Debug.Log("p[lanta n-are nevoie de apa ba ");
                }
            }
        }
        else
        {
            seedMenu.SetActive(true);
        }
    }
    private void Start()
    {
        for (int i=1; i < 17; i++)
        {
            needWaterIcons[i] = GameObject.Find("CanvasMeniu/pamantPlante/" + i + "/water" + i);
        }
        //InvokeRepeating("AutoSaveSoil", 5f, 5f);
        InvokeRepeating("timerPlantIncrease" , 1f, 1.0f);
        eroare = GameObject.Find("CanvasMeniu/EroarePlantare/Eroarea");
        seedInventory.SetActive(false);
        for(int i=0; i<17; i++)
        {
            MySQL.isPlanted[i] = false;
            MySQL.startTimer[i] = false;
            MySQL.timerPlantGrow[i] = 0;
            MySQL.soilPath[i] = "";

        }
        LoadGame();
        for (int j = 1; j < 5; j++)
        {
            isSoilUnlocked[j] = true;
        }
    }
    void timerPlantIncrease()
    {
        for(int i = 0; i < 17; i++) // verifica 17 pamanturi pe rand
        {
            if(MySQL.startTimer[i] == true) //daca pamantu respectiv are timeru pornit
            {
                if (MySQL.timerPlantGrow[i] > 19 && isPlantDead[i] != true) // daca timpu de la timer este gata
                {
                    switch (MySQL.whatPlant[i]) //switch ca sa verifice ce planta e pe pamant
                    {
                        case 1:
                            pamantAles[i] = GameObject.Find("CanvasMeniu/pamantPlante/" + i);
                            pamantAles[i].GetComponent<Image>().sprite = tomato;
                            pamantAles[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                            MySQL.plantState[i] = 3;

                            break;
                        case 2:
                            pamantAles[i] = GameObject.Find("CanvasMeniu/pamantPlante/" + i);
                            pamantAles[i].GetComponent<Image>().sprite = potato;
                            pamantAles[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                            MySQL.plantState[i] = 3;
                            break;
                        case 3:
                            pamantAles[i] = GameObject.Find("CanvasMeniu/pamantPlante/" + i);
                            pamantAles[i].GetComponent<Image>().sprite = carrot;
                            pamantAles[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                            MySQL.plantState[i] = 3;
                            break;
                        case 4:
                            pamantAles[i] = GameObject.Find("CanvasMeniu/pamantPlante/" + i);
                            pamantAles[i].GetComponent<Image>().sprite = corn;
                            pamantAles[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                            MySQL.plantState[i] = 3;
                            break;
                        case 5:
                            pamantAles[i] = GameObject.Find("CanvasMeniu/pamantPlante/" + i);
                            pamantAles[i].GetComponent<Image>().sprite = cucumber;
                            pamantAles[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                            MySQL.plantState[i] = 3;
                            break;
                        case 6:
                            pamantAles[i] = GameObject.Find("CanvasMeniu/pamantPlante/" + i);
                            pamantAles[i].GetComponent<Image>().sprite = eggplant;
                            pamantAles[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                            MySQL.plantState[i] = 3;
                            break;
                    }
                }
                else if (MySQL.timerPlantGrow[i] <= 20 && MySQL.startTimer[i] == true) //daca timeru nu e complet si timeru e inceput
                {
                    timerPlantGrow[i]++;  //cresc timeru cu 1 secunda
                    pamantAles[i] = GameObject.Find("CanvasMeniu/pamantPlante/" + i);
                    pamantAles[i].GetComponent<Image>().sprite = plantBegin;
                    pamantAles[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                    MySQL.timerPlantGrow[i]++;
                }
                if (startTimer[i] == true && plantWater[i] <= plantDeadTime)
                {
                    if(plantWater[i] > plantWaterTime)
                    {
                        needWaterIcons[i].SetActive(true);
                        soilNeedWater[i] = true;
                        plantWater[i]++;
                    }
                    else
                    {
                        plantWater[i]++;
                    }
                }
                else if (plantWater[i] >= plantDeadTime)
                {
                    needWaterIcons[i].SetActive(false);
                    soilNeedWater[i] = false;
                    isPlantDead[i] = true;
                    pamantAles[i] = GameObject.Find("CanvasMeniu/pamantPlante/" + i);
                    pamantAles[i].GetComponent<Image>().sprite = deadPlantImage;
                }

            }
        }
    }
    public void WaterPlants()
    {
        waterPlants = !waterPlants;
    }
    public void RemoveDeadPlant()
    {
        removeDeadPlant = !removeDeadPlant;
    }
    public void plantTomato()
    {           
        for (int i = 0; i < 17; i++)
        {
            if (i == pickedSoil)
            {
                if(MySQL.isPlanted[i] == false) //verific daca e deja o planta pe slotu ala si DACA NU E->
                {
                    MySQL.isPlanted[i] = true;
                    MySQL.startTimer[i] = true;
                    MySQL.whatPlant[i] = 1;
                    MySQL.plantState[i] = 1;
                    pamantAles[i] = GameObject.Find("CanvasMeniu/pamantPlante/" + i);
                    pamantAles[i].GetComponent<Image>().sprite = plantBegin;
                    pamantAles[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                    pickedSoil = 0;
                }
                else
                {
                    eroare.SetActive(true); //afiseaza eroarea
                }
            }
        }
    }
    public void plantPorumb()
    {
        for (int i = 0; i < 17; i++)
        {
            if (i == pickedSoil)
            {
                if (MySQL.isPlanted[i] == false)
                {
                    MySQL.isPlanted[i] = true;
                    MySQL.startTimer[i] = true;
                    MySQL.whatPlant[i] = 2;
                    MySQL.plantState[i] = 1;
                    pamantAles[i] = GameObject.Find("CanvasMeniu/pamantPlante/" + i);
                    pamantAles[i].GetComponent<Image>().sprite = plantBegin;
                    pamantAles[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                    pickedSoil = 0;
                }
                else
                {
                    eroare.SetActive(true);
                }
            }
        }
    }
    public void plantCarrot()
    {
        for (int i = 0; i < 17; i++)
        {
            if (i == pickedSoil)
            {
                if (MySQL.isPlanted[i] == false)
                {
                    MySQL.isPlanted[i] = true;
                    MySQL.startTimer[i] = true;
                    MySQL.whatPlant[i] = 3;
                    MySQL.plantState[i] = 1;
                    pamantAles[i] = GameObject.Find("CanvasMeniu/pamantPlante/" + i);
                    pamantAles[i].GetComponent<Image>().sprite = plantBegin;
                    pamantAles[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                    pickedSoil = 0;
                }
                else
                {
                    eroare.SetActive(true);
                }
            }
        }
    }
    public void plantPotato()
    {
        for (int i = 0; i < 17; i++)
        {
            if (i == pickedSoil)
            {
                if (MySQL.isPlanted[i] == false)
                {
                    MySQL.isPlanted[i] = true;
                    MySQL.startTimer[i] = true;
                    MySQL.whatPlant[i] = 4;
                    MySQL.plantState[i] = 1;
                    pamantAles[i] = GameObject.Find("CanvasMeniu/pamantPlante/" + i);
                    pamantAles[i].GetComponent<Image>().sprite = plantBegin;
                    pamantAles[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                    pickedSoil = 0;
                }
                else
                {
                    eroare.SetActive(true);
                }
            }
        }
    }
    public void plantCastravet()
    {
        for (int i = 0; i < 17; i++)
        {
            if (i == pickedSoil)
            {
                if (MySQL.isPlanted[i] == false)
                {
                    MySQL.isPlanted[i] = true;
                    MySQL.startTimer[i] = true;
                    MySQL.whatPlant[i] = 5;
                    MySQL.plantState[i] = 1;
                    pamantAles[i] = GameObject.Find("CanvasMeniu/pamantPlante/" + i);
                    pamantAles[i].GetComponent<Image>().sprite = plantBegin;
                    pamantAles[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                    pickedSoil = 0;
                }
                else
                {
                    eroare.SetActive(true);
                }
            }
        }
    }
    public void plantVanata()
    {
        for (int i = 0; i < 17; i++)
        {
            if (i == pickedSoil)
            {
                if (MySQL.isPlanted[i] == false)
                {
                    MySQL.isPlanted[i] = true;
                    MySQL.startTimer[i] = true;
                    MySQL.whatPlant[i] = 6;
                    MySQL.plantState[i] = 1;
                    pamantAles[i] = GameObject.Find("CanvasMeniu/pamantPlante/" + i);
                    pamantAles[i].GetComponent<Image>().sprite = plantBegin;
                    pamantAles[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                    pickedSoil = 0;
                }
                else
                {
                    eroare.SetActive(true);
                }
            }
        }
    }
    public int soilPicked()
    {
        return pickedSoil;
    }
    public void soil1()
    {
        pickedSoil = 1;
    }
    public void soil2()
    {
        pickedSoil = 2;
    }
    public void soil3()
    {
        pickedSoil = 3;
    }
    public void soil4()
    {
        pickedSoil = 4;
    }
    public void soil5()
    {
        pickedSoil = 5;
    }
    public void soil6()
    {
        pickedSoil = 6;
    }
    public void soil7()
    {
        pickedSoil = 7;
    }
    public void soil8()
    {
        pickedSoil = 8;
    }
    public void soil9()
    {
        pickedSoil = 9;
    }
    public void soilu10()
    {
        pickedSoil = 10;
    }
    public void soilu11()
    {
        pickedSoil = 11;
    }
    public void soilu12()
    {
        pickedSoil = 12;
    }
    public void soilu13()
    {
        pickedSoil = 13;
    }
    public void soilu14()
    {
        pickedSoil = 14;
    }
    public void soilu15()
    {
        pickedSoil = 15;
    }
    public void soilu16()
    {
        pickedSoil = 16;
    }
}
