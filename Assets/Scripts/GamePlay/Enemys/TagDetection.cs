using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TagDetection : MonoBehaviour
{
    public string objTag;
    [HideInInspector]
    public GameObject detectObject;
    public Vector2 targetPos;
    public float actionDistance;
    public bool inRange;


    // Start is called before the first frame update
    void Start()
    {
        detectObject = GameObject.FindGameObjectWithTag(objTag);
    }

    // Update is called once per frame
    void Update()
    {
        VerifyDist();
        targetPos = detectObject.transform.position;
    }

    public void VerifyDist()
    {
        if(Vector2.Distance(transform.position,detectObject.transform.position) <= actionDistance)
        {
            inRange = true;

        }
        else
        {
            inRange = false;
        }
    }
}
