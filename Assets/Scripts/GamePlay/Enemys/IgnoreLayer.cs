using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreLayer : MonoBehaviour
{
    public int ignoreLayerNum;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(gameObject.layer, ignoreLayerNum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
