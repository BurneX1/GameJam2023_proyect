using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyContrll : MonoBehaviour
{
    private EnemyFlyMove c_mov;
    private TagDetection c_plyrDetect;
    private BaseLife c_life;
    public float beforeAtkWaitTime;
    private float timer;
    public float chargeSpeed;
    Vector2 atackPos = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        c_mov = gameObject.GetComponent<EnemyFlyMove>();
        c_plyrDetect = gameObject.GetComponent<TagDetection>();
        c_life = gameObject.GetComponent<BaseLife>();
    }

    // Update is called once per frame
    void Update()
    {
        IApat();
        Die();
    }

    void Die()
    {
        if (c_life.actualHealth <= 0)
        {

            gameObject.SetActive(false);
        }
    }

    public void IApat()
    {
        if (c_plyrDetect.inRange)
        {
            timer += Time.deltaTime;

            if (timer <= beforeAtkWaitTime / 5)
            {
                atackPos = c_plyrDetect.targetPos;
                //Debug.Log(atackPos);
                //c_mov.TemporalPath(new Vector2(c_plyrDetect.targetPos.x - 1, transform.position.y), new Vector2(c_plyrDetect.targetPos.x + 1, transform.position.y));
            }
            if (timer >= beforeAtkWaitTime)
            {

                if (Vector2.Distance(transform.position, atackPos) < 0.05)
                {
                    gameObject.transform.position = atackPos;
                    //transform.rotation = new Quaternion(0, 0, 0,0);
                    timer = 0;

                }
                else
                {
                    Vector2 pos = Vector2.MoveTowards(transform.position, atackPos, chargeSpeed * Time.deltaTime);
                    Debug.Log(c_plyrDetect.targetPos);
                    //float rot_z = Mathf.Atan2(atackPos.y, atackPos.x) * Mathf.Rad2Deg;
                    //transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
                    gameObject.transform.position = pos;
                }
            }
            else
            {
                //transform.rotation = new Quaternion(0, 0, 0, 0);
                c_mov.TemporalPath(new Vector2(c_plyrDetect.targetPos.x - 1, c_plyrDetect.targetPos.y + 3), new Vector2(c_plyrDetect.targetPos.x + 1, c_plyrDetect.targetPos.y + 3));
            }

        }
        else
        {
            timer = 0;
            c_mov.Move();
            //transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    void Respawn()
    {
        c_life.actualHealth = c_life.maxHealth;

        gameObject.SetActive(true);
    }


}
