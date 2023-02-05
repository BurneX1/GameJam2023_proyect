using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using System.Linq;
using System;

public class RootZone : MonoBehaviour
{

    public SpriteRenderer RootHealtySpriteRender;

    public SpriteRenderer RootInfectedSpriteRender;


    // Start is called before the first frame update
    void Start()
    {
        

        UpdateRootState();
    }

    // Update is called once per frame
    void Update()
    {
        if ((DateTime.Now - lastUpdate).Milliseconds > 100)
            UpdateRootState();
    }

    private void UpdateRootState()
    {
        lastUpdate = DateTime.Now;

        EnemyController[] enemies = (EnemyController[])FindObjectsOfType(typeof(EnemyController));
        //Debug.Log("Number of enemies: " + enemies.Length );

        float rootZoneStart = this.transform.position.x;
        float rootZoneEnd = this.transform.position.x + 10;
        Debug.Log("Start: " + rootZoneStart + " End: " + rootZoneEnd);

        //Debug.Log("Location of root: " + rootZoneEnd);

        int countEnemies = 0;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (rootZoneStart <= enemies[i].transform.position.x &&
                enemies[i].transform.position.x < rootZoneEnd &&
                enemies[i]._collider.enabled)// FIX LATER, deberia haber una propiedad o el objeto ser destruido
                countEnemies++;
        } 

       // Object[] enemies = ObjectsOfType(typeof(EnemyController));
        Debug.Log("Number of enemies in zone: " + countEnemies);

        int clampCountEnemies = countEnemies > 4 ? 4 : countEnemies;

        rootHealt = 1.0f - clampCountEnemies / 4.0f;
        Debug.Log("rootHealt: " + rootHealt);


        if (RootHealtySpriteRender) RootHealtySpriteRender.color = new Color(1, 1, 1, rootHealt);
        if (RootInfectedSpriteRender) RootInfectedSpriteRender.color = new Color(1, 1, 1, 1- rootHealt);
    }

    private float rootHealt = 1;

    private DateTime lastUpdate;


}



