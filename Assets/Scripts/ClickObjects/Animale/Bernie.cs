using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bernie : GameConfig
{
    [SerializeField]
    GameObject bernieNormal;
    [SerializeField]
    GameObject bernieClicked;
    public void OnMouseOver()
    {
        if(isGamePaused == false)
        {
            if (gameObject.activeSelf == true)
            {
                bernieNormal.SetActive(false);
                bernieClicked.SetActive(true);
            }
        }
    }
    public void OnMouseExit()
    {
        bernieNormal.SetActive(true);
        bernieClicked.SetActive(false);
    }
}
