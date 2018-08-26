using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringWalls : MonoBehaviour
{
    //Make side walls into "goals" to score
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Ball")
        {
            string wallName = transform.name;
            Manager.Score(wallName);
            hitInfo.gameObject.SendMessage("Restart", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }
}
