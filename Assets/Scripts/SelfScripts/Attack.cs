using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public string[] colllisionTag;
    public AttackType atk;
    public GameObject collideObj;
    private Vector3 collPos;
    public int dir = 1;
    private float timer = 0;
    private bool timerOn;
    public void SetUpAttack()
    {
        collPos = new Vector3(
            transform.position.x + (atk.posVariation.x) * dir,
            transform.position.y + (atk.posVariation.y),
            transform.position.z);

        if (collideObj == null)
        {
 
            collideObj = new GameObject("collision");
            //collideObj.transform.parent = gameObject.transform;
            collideObj.name = "Collider";
            collideObj.SetActive(false);
            collideObj.AddComponent<BoxCollider2D>();
            collideObj.AddComponent<TrgDamage>();
            collideObj.GetComponent<TrgDamage>().dmgTagsArray = colllisionTag;
            collideObj.GetComponent<TrgDamage>().damage = atk.dmg;
            collideObj.GetComponent<TrgDamage>().disableOnHit = true;
            collideObj.GetComponent<BoxCollider2D>().isTrigger = true;
            //Añadir componente de triger de daño
        }

        
        collideObj.transform.position = new Vector3(collPos.x, collPos.y, collPos.z);
        collideObj.GetComponent<BoxCollider2D>().size = atk.hitRadio;
        Debug.Log("Attack SetUp");
    }

    private void Update()
    {
        timeToDisable();
    }
    public void timeToDisable()
    {
        if(timerOn)
        {
            timer += Time.deltaTime;
            if (timer >= atk.atkDur)
            {
                timer = 0;
                StopAtack();
                timerOn = false;
            }
        }
    }
    public void Atack()
    {
        SetUpAttack();


        if (collideObj.activeSelf ==false)
        {
            collideObj.SetActive(true);
            timerOn = true;
        }

        Debug.Log("Atack Start");
    }

    public void StopAtack()
    {
        if (collideObj.activeSelf == true)
        {
            collideObj.SetActive(false);
        }

        Debug.Log("Atack Stop");
    }


    private void OnDrawGizmos()
    {
       
        Gizmos.color = new Color(0, 1, 1, 0.12f);
        if(atk!=null)
        {
            Vector3 colPos = new Vector3(
                transform.position.x + (atk.posVariation.x) * dir,
                transform.position.y + (atk.posVariation.y),
                transform.position.z);
            Gizmos.DrawLine(transform.position, colPos);

            Gizmos.DrawCube(colPos, atk.hitRadio);
        }
        
    }
}
