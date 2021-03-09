using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button registerButton;
    public Button loginButton;
    public Button playButton;
    public GameObject updateVersionError;
    public TextMeshProUGUI playerDisplay;
    public void CheckVersion()
    {
        StartCoroutine(CheckVersionEnumerator());
    }
    IEnumerator CheckVersionEnumerator()
    {
        if (MySQL.localBuild)
        {
            WWW www = new WWW("http://localhost/connection/checkgameversion.php");
            yield return www;
            if (MySQL.gameVersionInGame != www.text)
            {
                loginButton.interactable = false;
                registerButton.interactable = false;
                updateVersionError.SetActive(true);
            }
        }
        else if(MySQL.localBuild == false)
        {
            WWW www = new WWW("http://79.118.153.175/connection/checkgameversion_online.php");
            yield return www;
            if (MySQL.gameVersionInGame != www.text)
            {
                loginButton.interactable = false;
                registerButton.interactable = false;
                updateVersionError.SetActive(true);
            }
        }
    }
    private void Start()
    {
        CheckVersion();
        if (MySQL.loggedIn)
        {
            playerDisplay.text = "Player: " + MySQL.username;
        }
        registerButton.interactable = !MySQL.loggedIn;
        loginButton.interactable = !MySQL.loggedIn;
        playButton.interactable = MySQL.loggedIn;
    }
    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToLogin()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToGame()
    {
        SceneManager.LoadScene(3);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
