using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System;

[Serializable]
public class PickSoil : MonoBehaviour
{
    
    public GameObject seedMenu;
    public GameObject seedInventory;
    private bool pickPlant = false;
    private bool[] alreadyPlanted = new bool[17]; //daca in slot e deja planta
    private int[] plantState = new int[17]; // 1=begin // 2=aproape gata(efecte) // 3=e gata(imagine floare)
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
    private Sprite tomatoBegin;
    [SerializeField]
    private Sprite grau;
    [SerializeField]
    private Sprite grauBegin;
    [SerializeField]
    private Sprite carrot;
    [SerializeField]
    private Sprite carrotBegin;
    [SerializeField]
    private Sprite potato;
    [SerializeField]
    private Sprite potatoBegin;
    [SerializeField]
    private Sprite cucumber;
    [SerializeField]
    private Sprite cucumberBegin;
    [SerializeField]
    private Sprite eggplant;
    [SerializeField]
    private Sprite eggPlantBegin;
    private GameObject[] pamantAles = new GameObject[17];
    private string[] pamantPath = new string[17];
    GameObject eroare;
    private Image[] imageOfPlant = new Image[17];
    private Button[] plantButtons = new Button[17];
    private int whatToPick = 1;
    private int[] rasamati = new int[17];
    [SerializeField]
    private Button adunaIarba;

    public void OnApplicationQuit()
    {
        CallSaveSoils();
    }
    public void CallLoadSoils()
    {
       
        StartCoroutine(LoadPlayerSoil());
    }
    IEnumerator LoadPlayerSoil()
    {
        for (int j = 0; j<17; j++)
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
                        for (int i = 0; i < 17; i++)
                        {
                            if (www.text.Split('\t')[i] == ("null") || www.text.Split('\t')[i] == "")
                            {
                                MySQL.soilPath[i] = "";
                            }
                            else if (www.text.Split('\t')[i] != "null" && www.text.Split('\t')[i] != "")
                            {
                                MySQL.soilPath[i] = www.text.Split('\t')[i];
                                pamantAles[i] = GameObject.Find(MySQL.soilPath[i]); //gaseste pamantu selectat
                                imageOfPlant[i] = pamantAles[i].GetComponent<Image>(); //ia componentu IMAGE de la obiect
                                plantButtons[i] = pamantAles[i].GetComponent<Button>();
                                imageOfPlant[i].sprite = tomatoBegin; //schimba imaginea la buto
                                imageOfPlant[i].color = new Color(191, 191, 191, 1);
                            }
                        }
                        whatToPick = 2;
                        break;
                    case 2:
                        for (int i = 0; i < 17; i++)
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
                        whatToPick = 3;
                        break;
                    case 3:
                        for (int i = 0; i < 17; i++)
                        {
                            int.TryParse(www.text.Split('\t')[i], out MySQL.whatPlant[i]);
                        }
                        whatToPick = 4;
                        break;
                    case 4:
                        for (int i = 0; i < 17; i++)
                        {
                            if (www.text.Split('\t')[i] == "True")
                            {
                                MySQL.startTimer[i] = true;
                            }
                            else if (www.text.Split('\t')[i] == "False")
                            {
                                MySQL.startTimer[i] = false;
                            }
                        }
                        whatToPick = 5;
                        break;
                    case 5:
                        for (int i = 0; i < 17; i++)
                        {
                            int.TryParse(www.text.Split('\t')[i], out MySQL.timerPlantGrow[i]);
                        }
                        whatToPick = 6;
                        break;
                    case 6:
                        for (int i = 0; i < 17; i++)
                        {
                            int.TryParse(www.text.Split('\t')[i], out MySQL.plantState[i]);
                        }
                        break;
                }
            }
            else if(MySQL.localBuild == false)
            {
                WWW www = new WWW("http://79.118.153.175/connection/loadsoils_online.php", form);
                yield return www;
                switch (whatToPick)
                {
                    case 1:
                        for (int i = 1; i < 17; i++)
                        {
                            if (www.text.Split('\t')[i] == ("null") || www.text.Split('\t')[i] == "")
                            {
                                MySQL.soilPath[i] = "";
                            }
                            else if (www.text.Split('\t')[i] != "null" && www.text.Split('\t')[i] != "")
                            {
                                MySQL.soilPath[i] = www.text.Split('\t')[i];
                                pamantAles[i] = GameObject.Find(MySQL.soilPath[i]); //gaseste pamantu selectat
                                imageOfPlant[i] = pamantAles[i].GetComponent<Image>(); //ia componentu IMAGE de la obiect
                                plantButtons[i] = pamantAles[i].GetComponent<Button>();
                                imageOfPlant[i].sprite = tomatoBegin; //schimba imaginea la buton
                            }
                        }
                        whatToPick = 2;
                        break;
                    case 2:
                        for (int i = 0; i < 17; i++)
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
                        whatToPick = 3;
                        break;
                    case 3:
                        for (int i = 0; i < 17; i++)
                        {
                            int.TryParse(www.text.Split('\t')[i], out MySQL.whatPlant[i]);
                        }
                        whatToPick = 4;
                        break;
                    case 4:
                        for (int i = 0; i < 17; i++)
                        {
                            if (www.text.Split('\t')[i] == "True")
                            {
                                MySQL.startTimer[i] = true;
                            }
                            else if (www.text.Split('\t')[i] == "False")
                            {
                                MySQL.startTimer[i] = false;
                            }
                        }
                        whatToPick = 5;
                        break;
                    case 5:
                        for (int i = 0; i < 17; i++)
                        {
                            int.TryParse(www.text.Split('\t')[i], out MySQL.timerPlantGrow[i]);
                        }
                        whatToPick = 6;
                        break;
                    case 6:
                        for (int i = 0; i < 17; i++)
                        {
                            int.TryParse(www.text.Split('\t')[i], out MySQL.plantState[i]);
                        }
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
        //WWWForm form = new WWWForm();
        //form.AddField("isPlanted", MySQL.isPlanted.ToString());
        MySQL.soilPath[0] = "";
        for(int i=0; i<17; i++)
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
            if (MySQL.localBuild)
            {
                WWW www = new WWW("http://localhost/connection/savesoil.php", form);
                yield return www;
            }
            else if(MySQL.localBuild == false)
            {
                WWW www = new WWW("http://79.118.153.175/connection/savesoil_online.php", form);
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
            if (MySQL.localBuild)
            {
                WWW www = new WWW("http://localhost/connection/savesoil.php", form);
                yield return www;
            }
            else if (MySQL.localBuild == false)
            {
                WWW www = new WWW("http://79.118.153.175/connection/savesoil_online.php", form);
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
            pamantAles[i] = GameObject.Find(MySQL.soilPath[i]);
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
                    if (MySQL.plantState[i] == 3)
                    {
                        switch (MySQL.whatPlant[i])
                        {
                            case 1:
                                MySQL.tomatoSeeds++;
                                imageOfPlant[i].sprite = null;
                                imageOfPlant[i].color = new Color(0f, 0f, 0f, .23f);
                                MySQL.isPlanted[i] = false;
                                MySQL.startTimer[i] = false;
                                MySQL.timerPlantGrow[i] = 0;
                                MySQL.plantState[i] = 0;
                                MySQL.soilPath[i] = "";
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
                                imageOfPlant[i].sprite = null;
                                imageOfPlant[i].color = new Color(0f, 0f, 0f, .23f);
                                MySQL.isPlanted[i] = false;
                                MySQL.startTimer[i] = false;
                                MySQL.timerPlantGrow[i] = 0;
                                MySQL.plantState[i] = 0;
                                MySQL.soilPath[i] = "";
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
                                imageOfPlant[i].sprite = null;
                                imageOfPlant[i].color = new Color(0f, 0f, 0f, .23f);
                                MySQL.isPlanted[i] = false;
                                MySQL.startTimer[i] = false;
                                MySQL.timerPlantGrow[i] = 0;
                                MySQL.plantState[i] = 0;
                                MySQL.soilPath[i] = "";
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
                                imageOfPlant[i].sprite = null;
                                imageOfPlant[i].color = new Color(0f, 0f, 0f, .23f);
                                MySQL.isPlanted[i] = false;
                                MySQL.startTimer[i] = false;
                                MySQL.timerPlantGrow[i] = 0;
                                MySQL.plantState[i] = 0;
                                MySQL.soilPath[i] = "";
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
                                imageOfPlant[i].sprite = null;
                                imageOfPlant[i].color = new Color(0f, 0f, 0f, .23f);
                                MySQL.isPlanted[i] = false;
                                MySQL.startTimer[i] = false;
                                MySQL.timerPlantGrow[i] = 0;
                                MySQL.plantState[i] = 0;
                                MySQL.soilPath[i] = "";
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
                                imageOfPlant[i].sprite = null;
                                imageOfPlant[i].color = new Color(0f, 0f, 0f, .23f);
                                MySQL.isPlanted[i] = false;
                                MySQL.startTimer[i] = false;
                                MySQL.timerPlantGrow[i] = 0;
                                MySQL.plantState[i] = 0;
                                MySQL.soilPath[i] = "";
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
        else
        {
            seedMenu.SetActive(true);
        }
    }
    private void Start()
    {
        InvokeRepeating("AutoSaveSoil", 5f, 5f);
        InvokeRepeating("timerPlantIncrease" , 0f, 1.0f);
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
    }
    void timerPlantIncrease()
    {

        /*verific fiecare pamant daca are floare pusa pe el
         * daca are floare-> verific cate secunde are la timer de la pamantu respectiv
         * daca are 10 secunde cresc floarea de pe pamantu ala
         * daca nu are 10 secunde adaug 1 secunda la timer
         * daca nu are floare nu fac nimic
         * 
         */
        for(int i = 0; i < 17; i++) // verifica 17 pamanturi pe rand
        {
            if(MySQL.startTimer[i] == true) //daca pamantu respectiv are timeru pornit
            {
                if (MySQL.timerPlantGrow[i] > 19) // daca timpu de la timer este gata
                {
                    switch (MySQL.whatPlant[i]) //switch ca sa verifice ce planta e pe pamant
                    {
                        case 1:
                            imageOfPlant[i].sprite = tomato;
                            imageOfPlant[i].color = new Color(255, 255, 255, 255);
                            MySQL.plantState[i] = 3;

                            break;
                        case 2:
                            imageOfPlant[i].sprite = grau;
                            imageOfPlant[i].color = new Color(255, 255, 255, 255);
                            MySQL.plantState[i] = 3;
                            break;
                        case 3:
                            imageOfPlant[i].sprite = carrot;
                            imageOfPlant[i].color = new Color(255, 255, 255, 255);
                            MySQL.plantState[i] = 3;
                            break;
                        case 4:
                            imageOfPlant[i].sprite = potato;
                            imageOfPlant[i].color = new Color(255, 255, 255, 255);
                            MySQL.plantState[i] = 3;
                            break;
                        case 5:
                            imageOfPlant[i].sprite = cucumber;
                            imageOfPlant[i].color = new Color(255, 255, 255, 255);
                            MySQL.plantState[i] = 3;
                            break;
                        case 6:
                            imageOfPlant[i].sprite = eggplant;
                            imageOfPlant[i].color = new Color(255, 255, 255, 255);
                            MySQL.plantState[i] = 3;
                            break;
                    }
                }
                else if (MySQL.timerPlantGrow[i] < 20 && MySQL.startTimer[i] == true) //daca timeru nu e complet si timeru e inceput
                {
                    timerPlantGrow[i]++;  //cresc timeru cu 1 secunda
                    MySQL.timerPlantGrow[i]++;
                }
            }
        }
    }
    
    public void plantTomato()
    {           
        for (int i = 0; i < 17; i++)
        {
            if (i == pickedSoil)
            {
                if(MySQL.isPlanted[i] == false) //verific daca e deja o planta pe slotu ala si DACA NU E->
                {
                    
                    pamantPath[i] = "CanvasMeniu/pamantPlante/" + i.ToString();
                    MySQL.soilPath[i] = "CanvasMeniu/pamantPlante/" + i.ToString();
                    MySQL.isPlanted[i] = true;
                    MySQL.startTimer[i] = true;
                    MySQL.whatPlant[i] = 1;
                    MySQL.plantState[i] = 1;
                    pamantAles[i] = GameObject.Find(MySQL.soilPath[i]); //gaseste pamantu selectat
                    imageOfPlant[i] = pamantAles[i].GetComponent<Image>(); //ia componentu IMAGE de la obiect
                    plantButtons[i] = pamantAles[i].GetComponent<Button>();
                    imageOfPlant[i].sprite = tomatoBegin; //schimba imaginea la buton
                    imageOfPlant[i].color = new Color(255, 255, 255, 255); //schimba culoarea sa se vada planta clar
                    //astea o sa le las in continuare ca sa se seteze cat e jocu pornit
                    //alreadyPlanted[i] = 1; //seteaza ca este deja o planta pusa
                    //plantState[i] = 1; // seteaza ca planta e la inceput
                    //startTimer[i] = 1; //incepe timpu sa numere pana creste planta
                    //whatPlant[i] = 1;
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
                    pamantPath[i] = "CanvasMeniu/pamantPlante/" + i.ToString();
                    MySQL.soilPath[i] = "CanvasMeniu/pamantPlante/" + i.ToString();
                    MySQL.isPlanted[i] = true;
                    MySQL.startTimer[i] = true;
                    MySQL.whatPlant[i] = 2;
                    MySQL.plantState[i] = 1;
                    pamantAles[i] = GameObject.Find(MySQL.soilPath[i]); //gaseste pamantu selectat
                    imageOfPlant[i] = pamantAles[i].GetComponent<Image>(); //ia componentu IMAGE de la obiect
                    plantButtons[i] = pamantAles[i].GetComponent<Button>();
                    imageOfPlant[i].sprite = grauBegin; //schimba imaginea la buton
                    imageOfPlant[i].color = new Color(255, 255, 255, 255); //schimba culoarea sa se vada planta clar
                    //alreadyPlanted[i] = 1;
                    //plantState[i] = 1;
                    //startTimer[i] = 1; //incepe timpu sa numere pana creste planta
                    //whatPlant[i] = 2; // seteaza ce planta e pe teren
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
                    pamantPath[i] = "CanvasMeniu/pamantPlante/" + i.ToString();
                    MySQL.soilPath[i] = "CanvasMeniu/pamantPlante/" + i.ToString();
                    MySQL.isPlanted[i] = true;
                    MySQL.startTimer[i] = true;
                    MySQL.whatPlant[i] = 3;
                    MySQL.plantState[i] = 1;
                    pamantAles[i] = GameObject.Find(MySQL.soilPath[i]); //gaseste pamantu selectat
                    imageOfPlant[i] = pamantAles[i].GetComponent<Image>(); //ia componentu IMAGE de la obiect
                    plantButtons[i] = pamantAles[i].GetComponent<Button>();
                    imageOfPlant[i].sprite = carrotBegin; //schimba imaginea la buton
                    imageOfPlant[i].color = new Color(255, 255, 255, 255); //schimba culoarea sa se vada planta clar
                    //alreadyPlanted[i] = 1;
                    //plantState[i] = 1;
                    //startTimer[i] = 1; //incepe timpu sa numere pana creste planta
                    //whatPlant[i] = 3; // seteaza ce planta e pe teren
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
                    pamantPath[i] = "CanvasMeniu/pamantPlante/" + i.ToString();
                    MySQL.soilPath[i] = "CanvasMeniu/pamantPlante/" + i.ToString();
                    MySQL.isPlanted[i] = true;
                    MySQL.startTimer[i] = true;
                    MySQL.whatPlant[i] = 4;
                    MySQL.plantState[i] = 1;
                    pamantAles[i] = GameObject.Find(MySQL.soilPath[i]); //gaseste pamantu selectat
                    imageOfPlant[i] = pamantAles[i].GetComponent<Image>(); //ia componentu IMAGE de la obiect
                    plantButtons[i] = pamantAles[i].GetComponent<Button>();
                    imageOfPlant[i].sprite = potatoBegin; //schimba imaginea la buton
                    imageOfPlant[i].color = new Color(255, 255, 255, 255); //schimba culoarea sa se vada planta clar
                    //alreadyPlanted[i] = 1;
                    //plantState[i] = 1;
                    //startTimer[i] = 1; //incepe timpu sa numere pana creste planta
                    //whatPlant[i] = 4; // seteaza ce planta e pe teren
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
                    pamantPath[i] = "CanvasMeniu/pamantPlante/" + i.ToString();
                    MySQL.soilPath[i] = "CanvasMeniu/pamantPlante/" + i.ToString();
                    MySQL.isPlanted[i] = true;
                    MySQL.startTimer[i] = true;
                    MySQL.whatPlant[i] = 5;
                    MySQL.plantState[i] = 1;
                    pamantAles[i] = GameObject.Find(MySQL.soilPath[i]); //gaseste pamantu selectat
                    imageOfPlant[i] = pamantAles[i].GetComponent<Image>(); //ia componentu IMAGE de la obiect
                    plantButtons[i] = pamantAles[i].GetComponent<Button>();
                    imageOfPlant[i].sprite = cucumberBegin; //schimba imaginea la buton
                    imageOfPlant[i].color = new Color(255, 255, 255, 255); //schimba culoarea sa se vada planta clar
                    //alreadyPlanted[i] = 1;
                    //plantState[i] = 1;
                    //startTimer[i] = 1; //incepe timpu sa numere pana creste planta
                    //whatPlant[i] = 5; // seteaza ce planta e pe teren
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
                    pamantPath[i] = "CanvasMeniu/pamantPlante/" + i.ToString();
                    MySQL.soilPath[i] = "CanvasMeniu/pamantPlante/" + i.ToString();
                    MySQL.isPlanted[i] = true;
                    MySQL.startTimer[i] = true;
                    MySQL.whatPlant[i] = 6;
                    MySQL.plantState[i] = 1;
                    pamantAles[i] = GameObject.Find(MySQL.soilPath[i]); //gaseste pamantu selectat
                    imageOfPlant[i] = pamantAles[i].GetComponent<Image>(); //ia componentu IMAGE de la obiect
                    plantButtons[i] = pamantAles[i].GetComponent<Button>();
                    imageOfPlant[i].sprite = eggPlantBegin; //schimba imaginea la buton
                    imageOfPlant[i].color = new Color(255, 255, 255, 255); //schimba culoarea sa se vada planta clar
                    //alreadyPlanted[i] = 1;
                    //plantState[i] = 1;
                    //startTimer[i] = 1; //incepe timpu sa numere pana creste planta
                    //whatPlant[i] = 6; // seteaza ce planta e pe teren
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
