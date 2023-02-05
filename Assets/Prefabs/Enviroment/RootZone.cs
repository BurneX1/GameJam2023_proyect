using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;
using System.Linq;
using System;
using UnityEngine.Events;
public class RootZone : MonoBehaviour
{

    public SpriteRenderer RootHealtySpriteRender;

    public SpriteRenderer RootInfectedSpriteRender;

    

    public float rootHealt = 0;
    private bool healthCheck = false;

    public UnityEvent onClearEvent;


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
        CheckSelfHealth();
    }

    private void UpdateRootState()
    {
        lastUpdate = DateTime.Now;

        EnemyController[] enemies = (EnemyController[])FindObjectsOfType(typeof(EnemyController));
        InfectedObject[] infected = (InfectedObject[])FindObjectsOfType(typeof(InfectedObject));

        //Debug.Log("Number of enemies: " + enemies.Length );

        float rootZoneStart = this.transform.position.x;
        float rootZoneEnd = this.transform.position.x + 10;
        //Debug.Log("Start: " + rootZoneStart + " End: " + rootZoneEnd);

        //Debug.Log("Location of root: " + rootZoneEnd);

        int countEnemies = 0;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (rootZoneStart <= enemies[i].transform.position.x &&
                enemies[i].transform.position.x < rootZoneEnd &&
                enemies[i]._collider.enabled)// FIX LATER, deberia haber una propiedad o el objeto ser destruido
                countEnemies++;
        } 
        for (int i = 0; i < infected.Length; i++)
        {
            if (rootZoneStart <= infected[i].transform.position.x &&
                infected[i].transform.position.x < rootZoneEnd &&
                infected[i].infectionPercentage > 0)
                countEnemies++;
        } 
       // Object[] enemies = ObjectsOfType(typeof(EnemyController));
        //Debug.Log("Number of enemies in zone: " + countEnemies);

        int clampCountEnemies = countEnemies > 4 ? 4 : countEnemies;

        rootHealt = 1.0f - clampCountEnemies / 4.0f;
        //Debug.Log("rootHealt: " + rootHealt);


        if (RootHealtySpriteRender) RootHealtySpriteRender.color = new Color(1, 1, 1, rootHealt);
        if (RootInfectedSpriteRender) RootInfectedSpriteRender.color = new Color(1, 1, 1, 1- rootHealt);
    }

    private void CheckSelfHealth()
    {
        if(rootHealt < 1)
        {
            return;
        }

        if(healthCheck == false)
        {
            Debug.Log(gameObject.name + " " + "healthCheckrealized");
            healthCheck = true;
            onClearEvent.Invoke();
        }
    }
    private DateTime lastUpdate;


}



