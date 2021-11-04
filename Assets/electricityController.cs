using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricityController : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GameEvents.current.lightUpTheDarkTrigger += OnLightUp;
    }

    private void OnLightUp(){
        GameEvents.current.lightUp = true;
    }
}
