using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
public class Register : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public Button submitButton;
    public TextMeshProUGUI showeror;
    public void CallRegister()
    {
        StartCoroutine(Registration());
    }
    IEnumerator Registration()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        if (MySQL.localBuild)
        {
            WWW www = new WWW("http://localhost/connection/register.php", form);
            yield return www;
            if (www.text == "0")
            {
                Debug.Log("User created succesfully");
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);

            }
            else
            {
                Debug.Log("User creation failed. Error #" + www.text);
            }
        }
        else if(MySQL.localBuild == false)
        {
            WWW www = new WWW("http://79.118.153.175/connection/register_online.php", form);
            yield return www;
            if (www.text == "0")
            {
                Debug.Log("User created succesfully");
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
            else
            {
                Debug.Log("User creation failed. Error #" + www.text);
                showeror.text = www.text;
            }
        }
    }
    public void GoToMainWindow()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 5 && passwordField.text.Length >= 5);
    }
}
