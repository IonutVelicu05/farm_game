using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Putin : GameConfig
{
    [SerializeField]
    GameObject putinNormal;
    [SerializeField]
    GameObject putinClicked;

    public void OnMouseEnter()
    {
        if(isGamePaused == false)
        {
            if (gameObject.activeSelf == true)
            {
                putinNormal.SetActive(false);
                putinClicked.SetActive(true);
            }
        }
    }
    public void OnMouseExit()
    {
        putinNormal.SetActive(true);
        putinClicked.SetActive(false);
    }
}
