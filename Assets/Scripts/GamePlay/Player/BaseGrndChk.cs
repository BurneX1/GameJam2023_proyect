using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGrndChk : MonoBehaviour
{
    
    public Transform actualGround;
    public float coyote;
    private float timer;
    private BoxCollider2D cmp_coll;

    private void Awake()
    {
        cmp_coll = gameObject.GetComponent<BoxCollider2D>();
    }
    public bool GroundLayerCheck(LayerMask mask, float distance)
    {
        /*RaycastHit2D hit = Physics2D.Raycast(transform.position,
           Vector2.down,
           distance,
           mask);

        bool grn = Physics2D.Raycast(transform.position,
           Vector2.down,
           distance,
           mask);*/

        RaycastHit2D hit = Physics2D.BoxCast
            (
            transform.position,
            new Vector2((cmp_coll.size.x)*0.65f, 0.1f),
            0,
            Vector2.down,
            distance,
            mask
            );
        bool grn = Physics2D.BoxCast
            (
            transform.position,
            new Vector2((cmp_coll.size.x) * 0.65f, 0.1f),
            0,
            Vector2.down,
            distance,
            mask
            );


        if (hit.collider != null) 
        {
            actualGround = hit.collider.transform; 
        }
        else
        {
            actualGround = null;
        }

        if (grn == true)
        {
            timer = 0f;
            return true;
        }
        else if (timer <= coyote)
        {
            timer += Time.deltaTime;
        }

        if (timer >= coyote)
        {
            return false;
        }
        else
        {
            return true;
        }
       
    }

    public void ForceEndCoyote()
    {
        timer = coyote;
    }

}
