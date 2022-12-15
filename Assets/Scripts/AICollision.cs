using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "AI")
        {
            Debug.Log("Player collided with AI Car");
            Time.timeScale = 0;
            // trigger game over screen
            GameState.instance.gameOver();
        }
    }
}
