using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadworkTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameState.instance.gameOver();
        }
    }
}
