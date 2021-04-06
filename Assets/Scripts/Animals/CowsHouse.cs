using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CowsHouse : MonoBehaviour
{
    public void changeScene() // change scene to cowshed when teleport button is pressed
    {
        SceneManager.LoadScene(4);
    }
}
