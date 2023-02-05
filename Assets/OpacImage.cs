using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpacImage : MonoBehaviour
{
    [Range(1, 10)]
    public float uiReactSpd=1;
    public Image img;
    public float alpha;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Opac(img, alpha);
    }

    public void ChangeAlpha(float alph)
    {
        alpha = alph;
    }
    private void Opac(Image box, float alpha)
    {
        if (box.color.a != alpha)
        {
            box.color = new Color(box.color.r, box.color.g, box.color.b, Mathf.Lerp(box.color.a, alpha, Time.deltaTime * uiReactSpd));
        }
    }
}
