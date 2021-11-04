using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    public bool lightUp = false;

    private void Awake(){
        current = this;
    }

    public event Action lightUpTheDarkTrigger;
    public void lightUpTheDark(){
        if (lightUpTheDarkTrigger != null)
        {
            lightUpTheDarkTrigger();
        }
    }
}
