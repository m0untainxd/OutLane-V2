using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //lose coins
            GameState.instance.hitSand();
            //set to middle lane
            Follower.instance.setLane(1);
        }
    }
}
