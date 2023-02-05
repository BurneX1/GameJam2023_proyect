using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrdMove : MonoBehaviour
{
    private Rigidbody2D c_rb;
    private BoxCollider2D c_coll;

    public float spd;
    public int dir;
    public bool letFall;
    public float layerCheckDistance;
    public LayerMask collisionLayer;
    // Start is called before the first frame update
    void Start()
    {
        c_rb = gameObject.GetComponent<Rigidbody2D>();
        c_coll = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        LateralCheck();
        DownCheck();
        c_rb.velocity = new Vector2(spd * dir, c_rb.velocity.y);
    }

    public void ChangeDir()
    {
        dir = dir * -1;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    private void LateralCheck()
    {
        if(Physics2D.Raycast(transform.position,
           Vector2.right * dir,
           layerCheckDistance,
           collisionLayer))
        {
            ChangeDir();
        }
    }

    private void DownCheck()
    {
        if (Physics2D.Raycast(transform.position + new Vector3(c_coll.bounds.size.x/2 * dir,0,0),
           Vector2.down,
           layerCheckDistance,
           collisionLayer) == false && letFall == false)
        {
            ChangeDir();
        }
    }
}
