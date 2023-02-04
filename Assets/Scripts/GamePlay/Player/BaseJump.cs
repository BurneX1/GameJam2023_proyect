using UnityEngine;
using System;

public class BaseJump : MonoBehaviour
{
    public event Action Jumped = delegate { };
    private Rigidbody2D c_rb;

    public float minHeight;
    public float maxHeight;
    private float  minSpd;
    private float maxSpd;
    private Vector2 jmpStrPos;
    private float spd;

    private void Awake()
    {
        c_rb = gameObject.GetComponent<Rigidbody2D>();

        minSpd = Mathf.Sqrt(0 - (2 * -9.8f * minHeight));
        maxSpd = Mathf.Sqrt(0 - (2 * -9.8f * maxHeight));
    }

    public void Jump(float getPress)
    {
        if (getPress < minSpd)
        {
            getPress = minSpd;
        }
        else if (getPress > maxSpd)
        {
            getPress = maxSpd;
        }

        c_rb.velocity += new Vector2(0, getPress);
    }

    public void Jump(bool check)
    {
        
        if (check==true)
        {
            jmpStrPos = gameObject.transform.position;
            spd = minSpd;
            Jumped.Invoke();
        }
        if (spd > Mathf.Sqrt((minSpd * minSpd) + (2 * (-9.8f -(-minSpd / (2 * maxHeight / (minSpd + 0)))) * maxHeight)))
        {
            spd += (-9.8f -(-minSpd/(2*maxHeight/(minSpd+0)))) * Time.deltaTime;
            
            c_rb.velocity = new Vector2(c_rb.velocity.x, spd);
        }

        
    }
    public void ForceJump(float forceHeight)
    {
        c_rb.velocity = new Vector2(c_rb.velocity.x, Mathf.Sqrt(0 - (2 * -9.8f * forceHeight)));
    }

}
