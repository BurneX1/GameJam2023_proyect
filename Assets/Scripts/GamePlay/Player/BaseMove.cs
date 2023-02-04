using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class BaseMove : MonoBehaviour
{
    private Rigidbody2D c_rb;

    public float iSpd;
    public float fSpd;
    public float acelTime;
    [HideInInspector]
    public float spdValue;
    private float aceleration;
    [HideInInspector]

    private void Awake()
    {
        c_rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void HorMov(float dir)
    {
        aceleration = (fSpd - iSpd) / acelTime;
        if(Mathf.Abs(c_rb.velocity.x) <= 0.3)
        {
            spdValue = 0;   
        }

        if (spdValue <= fSpd)
        {
            if(spdValue < iSpd)
            {
                spdValue = iSpd;
            }
            float tmpSpd = Time.deltaTime * (aceleration / 0.4f);

            spdValue += tmpSpd;
        }
        else
        {
            spdValue = fSpd;
        }

        c_rb.velocity = new Vector2((spdValue) * dir, c_rb.velocity.y);
    }

}
