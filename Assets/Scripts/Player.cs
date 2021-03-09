using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    //stats
    private string playerName;
    private int playerMoney;
    private int playerLevel;
    private float playerExperience;
    private float experienceNeeded;
    //inventory
    private int tomatoSeeds;
    private int cucumberSeeds;
    private int potatoSeeds;
    private int eggplantSeeds;
    private int cornSeeds;
    private int carrotSeeds;
    public Slider experienceBar;
    [SerializeField]
    TextMeshProUGUI playerNameObj;
    [SerializeField]
    TextMeshProUGUI moneyObj;
    [SerializeField]
    TextMeshProUGUI playerLevelObj;
    [SerializeField]
    TextMeshProUGUI playerExpObj;
    [SerializeField]
    TextMeshProUGUI expNeededObj;
    [SerializeField]
    TextMeshProUGUI tomatoSeedsObj;
    [SerializeField]
    TextMeshProUGUI cucumberSeedsObj;
    [SerializeField]
    TextMeshProUGUI potatoSeedsObj;
    [SerializeField]
    TextMeshProUGUI eggplantSeedsObj;
    [SerializeField]
    TextMeshProUGUI cornSeedsObj;
    [SerializeField]
    TextMeshProUGUI carrotSeedsObj;
    public void OnApplicationQuit()
    {
        CallSaveData();
    }
    private void Start()
    {
        InvokeRepeating("CallAutoUpdate", 0f, 2f);
        InvokeRepeating("CallSaveData", 0f, 10f);
        InvokeRepeating("updateData", 0f, 1f);
        if(MySQL.username == null)
        {
            MySQL.LogOut();
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        playerName = MySQL.username;
        playerNameObj.text = playerName;
        experienceBar.value = MySQL.playerExperience;
        playerLevelObj.text = MySQL.level.ToString();
        tomatoSeedsObj.text = MySQL.tomatoSeeds.ToString();
        cornSeedsObj.text = MySQL.cornSeeds.ToString();
        cucumberSeedsObj.text = MySQL.cucumberSeeds.ToString();
        potatoSeedsObj.text = MySQL.potatoSeeds.ToString();
        eggplantSeedsObj.text = MySQL.eggplantSeeds.ToString();
        carrotSeedsObj.text = MySQL.carrotSeeds.ToString();
        expNeededObj.text = MySQL.experienceNeeded.ToString();
        playerExpObj.text = MySQL.playerExperience.ToString();
        moneyObj.text = MySQL.money.ToString();
    }
    //functie care actualizeaza GUI din joc si pune valorile luate din database
    public void updateData()
    {
        playerLevelObj.text = MySQL.level.ToString();
        tomatoSeedsObj.text = MySQL.tomatoSeeds.ToString();
        cornSeedsObj.text = MySQL.cornSeeds.ToString();
        cucumberSeedsObj.text = MySQL.cucumberSeeds.ToString();
        potatoSeedsObj.text = MySQL.potatoSeeds.ToString();
        eggplantSeedsObj.text = MySQL.eggplantSeeds.ToString();
        carrotSeedsObj.text = MySQL.carrotSeeds.ToString();
        expNeededObj.text = MySQL.experienceNeeded.ToString();
        playerExpObj.text = MySQL.playerExperience.ToString();
        moneyObj.text = MySQL.money.ToString();
        experienceBar.value = MySQL.playerExperience;
        experienceBar.maxValue = MySQL.experienceNeeded;
    }
    //functie care salveaza datele contului in database
    public void CallSaveData()
    {
        StartCoroutine(SavePlayerData());
    }
    IEnumerator SavePlayerData()
    {
        updateData();
        WWWForm form = new WWWForm();
        form.AddField("name", MySQL.username);
        form.AddField("level", MySQL.level);
        form.AddField("money", MySQL.money);
        form.AddField("experience", MySQL.playerExperience);
        form.AddField("experienceNeeded", MySQL.experienceNeeded);
        form.AddField("tomatoSeeds", MySQL.tomatoSeeds);
        form.AddField("cornSeeds", MySQL.cornSeeds);
        form.AddField("carrotSeeds", MySQL.carrotSeeds);
        form.AddField("cucumberSeeds", MySQL.cucumberSeeds);
        form.AddField("potatoSeeds", MySQL.potatoSeeds);
        form.AddField("eggplantSeeds", MySQL.eggplantSeeds);
        if (MySQL.localBuild)
        {
            WWW www = new WWW("http://localhost/connection/savedata.php", form);
            //WWW www = new WWW("http://79.118.153.175/connection/savedata_online.php", form);
            yield return www;
        }
        else if(MySQL.localBuild == false)
        {
            WWW www = new WWW("http://79.118.153.175/connection/savedata_online.php", form);
            yield return www;
        }
    }
    public void CallAutoUpdate()
    {
        StartCoroutine(CallAutoUpdateEnumerator());
    }
    IEnumerator CallAutoUpdateEnumerator()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", MySQL.username);
        if (MySQL.localBuild)
        {
            WWW www = new WWW("http://localhost/connection/updatestats.php", form);
            yield return www;
            if (www.text[0] == '0')
            {
                MySQL.level = int.Parse(www.text.Split('\t')[1]);
                MySQL.money = int.Parse(www.text.Split('\t')[2]);
                MySQL.playerExperience = int.Parse(www.text.Split('\t')[3]);
                MySQL.experienceNeeded = int.Parse(www.text.Split('\t')[4]);
                MySQL.tomatoSeeds = int.Parse(www.text.Split('\t')[5]);
                MySQL.cornSeeds = int.Parse(www.text.Split('\t')[6]);
                MySQL.carrotSeeds = int.Parse(www.text.Split('\t')[7]);
                MySQL.cucumberSeeds = int.Parse(www.text.Split('\t')[8]);
                MySQL.potatoSeeds = int.Parse(www.text.Split('\t')[9]);
                MySQL.eggplantSeeds = int.Parse(www.text.Split('\t')[10]);
                MySQL.newAccount = int.Parse(www.text.Split('\t')[11]);
            }
        }
        else if (MySQL.localBuild == false)
        {
            WWW www = new WWW("http://79.118.153.175/connection/updatestats_online.php", form);
            yield return www;
            if (www.text[0] == '0')
            {
                MySQL.level = int.Parse(www.text.Split('\t')[1]);
                MySQL.money = int.Parse(www.text.Split('\t')[2]);
                MySQL.playerExperience = int.Parse(www.text.Split('\t')[3]);
                MySQL.experienceNeeded = int.Parse(www.text.Split('\t')[4]);
                MySQL.tomatoSeeds = int.Parse(www.text.Split('\t')[5]);
                MySQL.cornSeeds = int.Parse(www.text.Split('\t')[6]);
                MySQL.carrotSeeds = int.Parse(www.text.Split('\t')[7]);
                MySQL.cucumberSeeds = int.Parse(www.text.Split('\t')[8]);
                MySQL.potatoSeeds = int.Parse(www.text.Split('\t')[9]);
                MySQL.eggplantSeeds = int.Parse(www.text.Split('\t')[10]);
                MySQL.newAccount = int.Parse(www.text.Split('\t')[11]);
            }
        }
    }
}
