using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doge : GameConfig
{
    [SerializeField]
    GameObject dogeClicked;
    [SerializeField]
    GameObject dogeNormal;

    public void OnMouseOver()
    {
        if (isGamePaused == false)
        {
            if (gameObject.activeSelf == true)
            {
                dogeNormal.SetActive(false);
                dogeClicked.SetActive(true);
            }
        }
    }
    public void OnMouseExit()
    {
        dogeNormal.SetActive(true);
        dogeClicked.SetActive(false);
    }
}
