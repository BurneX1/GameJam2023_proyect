using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CollectTriger : MonoBehaviour
{

    public bool nonDisable;



    public UnityEvent extraFuncts;
    public UnityEvent exitFuncts;
    public string[] collisionTags;
    [HideInInspector]
    public GameObject enterObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Execute(GameObject externalIntrcter)
    {
        extraFuncts.Invoke();
        if(nonDisable ==false)
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < collisionTags.Length; i++)
        {
            if (collision.gameObject.tag == collisionTags[i])
            {
                enterObj = collision.gameObject;
   
                    Execute(collision.gameObject);
                
                
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        for (int i = 0; i < collisionTags.Length; i++)
        {
            if (collision.gameObject == enterObj)
            {
                exitFuncts.Invoke();
                enterObj = null;
            }
        }
    }
}
