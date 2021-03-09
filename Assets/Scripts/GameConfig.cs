using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    public bool isGamePaused = false;
    
    public void punePauza()
    {
        isGamePaused = !isGamePaused;
    }
    
}
