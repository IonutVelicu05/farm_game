using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Login : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public Button submitButton;
    public TextMeshProUGUI showerror;
    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }
    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        if (MySQL.localBuild)
        {
            WWW www = new WWW("http://localhost/connection/login.php", form);
            yield return www;
            if (www.text[0] == '0')
            {
                MySQL.username = nameField.text;
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
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
            else
            {
                Debug.Log("User login failed. Error #" + www.text);
            }
        }
        else if (MySQL.localBuild == false)
        {
            WWW www = new WWW("http://guta-farm.000webhostapp.com/connection/login_online.php", form);
            yield return www;
            if (www.text[0] == '0')
            {
                MySQL.username = nameField.text;
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
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
            else
            {
                Debug.Log("User login failed. Error #" + www.text);
                showerror.text = www.text;
            }
        }
    }
    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 5 && passwordField.text.Length >= 5);
    }
}
