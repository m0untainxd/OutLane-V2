using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newLap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameState.instance.lap();
        }
        
    }
}
