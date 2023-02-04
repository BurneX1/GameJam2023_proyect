using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public SpawnPoint spwPoint;
    
    public void ReSpawn()
    {
        if(gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
        }

        gameObject.transform.position = new Vector2(spwPoint.x, spwPoint.y);
    }
}
