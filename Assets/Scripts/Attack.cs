using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public string colllisionTag;
    public AttackType atk;
    public GameObject collideObj;
    private Vector3 collPos;
    public void SetUpAttack()
    {
        collPos = new Vector3(
            transform.position.x + (atk.posVariation.x) * transform.localScale.x,
            transform.position.y + (atk.posVariation.y) * transform.localScale.y,
            transform.position.z);
        if (collideObj == null)
        {
 
            collideObj = new GameObject("collision");
            collideObj.name = "Collider";
            collideObj.SetActive(false);
            collideObj.AddComponent<BoxCollider2D>();
            //Añadir componente de triger de daño
        }

        
        collideObj.transform.position = new Vector3(collPos.x, collPos.y, collPos.z);
        collideObj.GetComponent<BoxCollider2D>().size = atk.hitRadio;
        Debug.Log("Attack SetUp");
    }

    public void Atack()
    {
        SetUpAttack();


        if (collideObj.activeSelf ==false)
        {
            collideObj.SetActive(true);
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

        Vector3 colPos = new Vector3(
                transform.position.x + (atk.posVariation.x) * transform.localScale.x,
                transform.position.y + (atk.posVariation.y) * transform.localScale.y,
                transform.position.z);
        Gizmos.DrawLine(transform.position, colPos);

        Gizmos.DrawCube(colPos, atk.hitRadio);
    }
}
