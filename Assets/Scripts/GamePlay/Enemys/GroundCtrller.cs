using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EnemyGrdMove))]
public class GroundCtrller : MonoBehaviour
{
    private EnemyGrdMove c_mov;

    private BaseLife c_life;
    //private Animator c_anim;
    private Rigidbody2D c_rb;
    // Start is called before the first frame update
    void Start()
    {
        c_mov = gameObject.GetComponent<EnemyGrdMove>();

        c_life = gameObject.GetComponent<BaseLife>();
        //c_anim = gameObject.GetComponent<Animator>();
        c_rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        c_mov.Move();
        //c_anim.SetFloat("Spd", Mathf.Abs(c_rb.velocity.x));
        Die();
    }

    void Die()
    {
        if(c_life.actualHealth <= 0)
        {

            gameObject.SetActive(false);
        }
    }

    void Respawn()
    {
        c_life.actualHealth = c_life.maxHealth;

        gameObject.SetActive(true);
    }
}
