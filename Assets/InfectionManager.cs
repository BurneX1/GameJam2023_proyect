using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionManager : MonoBehaviour
{
    public RootZone[] Roots;

    public Transform InfectZoneTrab;


    // Start is called before the first frame update
    void Start()
    {
        CheckRootsAndUpdateInfection();
    }

    // Update is called once per frame
    void Update()
    {
        if ((DateTime.Now - lastUpdate).Milliseconds > 100)
            CheckRootsAndUpdateInfection();
    }

    void CheckRootsAndUpdateInfection()
    {
        lastUpdate = DateTime.Now;

        for (int i = infectionIndexPosition; i < Roots.Length; i++) 
        {
            if (Roots[i] != null)
            {
                if (Roots[i].rootHealt < 1)
                {
                    infectionIndexPosition = i;
                    Debug.Log("Min Infected zone " + infectionIndexPosition);
                    InfectZoneTrab.transform.SetPositionAndRotation(new Vector3((infectionIndexPosition + 1) * 10, 0, 0), new Quaternion());

                    Debug.Log("Infection zone in zone " + infectionIndexPosition);

                    break;
                }
            }
        }

    }

    private DateTime lastUpdate;

    private int infectionIndexPosition = 0;
}
