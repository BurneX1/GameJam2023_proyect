using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public string colllisionTag;
    public AttackType atk;
    public GameObject collideObj;
    public void SetUpAttack()
    {
        if (collideObj != null)
        {
            collideObj = Instantiate(new GameObject("collision"), gameObject.transform);
            collideObj.SetActive(false);
        }

        collideObj.transform.position = 
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
        Debug.Log("Atack Stop");
    }


    private void OnDrawGizmos()
    {
       
        Gizmos.color = new Color(0, 1, 1, 0.12f);

        Vector3 collPos = new Vector3(
            transform.position.x + (atk.posVariation.x) * transform.localScale.x,
            transform.position.y + (atk.posVariation.y) * transform.localScale.y,
            transform.position.z);
        Gizmos.DrawLine(transform.position, collPos);

        Gizmos.DrawCube(collPos, atk.hitRadio);
    }
}
