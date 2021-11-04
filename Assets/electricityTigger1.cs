using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricityTigger1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKey(KeyCode.E)){
            GameEvents.current.lightUpTheDark();
        }  
    }
}
