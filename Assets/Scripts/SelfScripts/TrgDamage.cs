using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrgDamage : MonoBehaviour
{
    public int damage;
    public string[] dmgTagsArray;
    public float timePerDmg;
    public bool disableOnHit;
    private float timer;
    private bool doDmg;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ReduceTime();
    }

    public void Damage(Collider2D other)
    {
        if (timer <= 0 && doDmg == true)
        {

            if (other.gameObject.GetComponent<BaseLife>())
            {
                other.gameObject.GetComponent<BaseLife>().ReduceLife(damage);
            }
            
            timer = timePerDmg;
        }
    }

    void ReduceTime()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        for (int i = 0; i < dmgTagsArray.Length; i++)
        {
            if (other.gameObject.tag == dmgTagsArray[i])
            {
                doDmg = true;
                timer = 0;
                Damage(other);
            }
        }
        if (disableOnHit == true)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        for (int i = 0; i < dmgTagsArray.Length; i++)
        {
            if (other.gameObject.tag == dmgTagsArray[i])
            {
                Damage(other);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        for (int i = 0; i < dmgTagsArray.Length; i++)
        {
            if (other.gameObject.tag == dmgTagsArray[i])
            {
                doDmg = false;
                timer = timePerDmg;
            }
        }
    }

    private void OnEnable()
    {
        timer = 0;
    }
}
